import angular = require("angular");
import $ = require("jquery");
import App = require("../layout/apps");
import toastr = require("toastr");

angular.module("gvApp.modules")
    .controller("bookingController", bookingController);

bookingController.$inject = ["$scope", "$rootScope", "bookingService", "$modal", "$state", "appConfig"];

function bookingController($scope: angular.IScope, $rootScope, bookingService, $modal, $state: angular.ui.IStateService, appConfig) {
    // $rootScope.setting.layout.pageContentFullWidth = true;
    var weekday = new Array(7);
    weekday[0] = "日";
    weekday[1] = "一";
    weekday[2] = "二";
    weekday[3] = "三";
    weekday[4] = "四";
    weekday[5] = "五";
    weekday[6] = "六";
    var vm = this;
    vm.step = 2;
    vm.setAdult = setAdult;
    vm.selectDateTitle = "";
    vm.arrival = { mon: '01', day: '01', week: '一' };
    vm.departure = { mon: '01', day: '01', week: '一', days: 1 };
    vm.addArrival = addArrival;
    vm.addDeparture = addDeparture;
    vm.selectArrival = selectArrival;
    vm.selectDeparture = selectDeparture;
    vm.selectedDate = selectedDate;
    vm.item = {
        //GuestId: appConfig.config.user.Id,
        Guest: appConfig.config.user,
        Adult: 1,

    };
    vm.roomtypes = [];
    vm.dateQuery = dateQuery;
    vm.VerifyCode = "";
    vm.code = 0;
    vm.getVerifyCode = getVerifyCode;
    vm.resvnum = "";
    vm.roomQuery = roomQuery;
    vm.backQuery = backQuery;
    vm.booking = booking;
    vm.subimtResv = subimtResv;
    vm.bookingNext = bookingNext;
    active();

    function active() {
        //vm.step = 2;
        setArrival(getDate(0));
        setDeparture(getDate(1));

        $('#datepicker-inline').datepicker({
            todayHighlight: true,
            language: "zh-CN",
            //orientation: "bottom",
            startDate: getDate(0),
            endDate: getDate(60)
        });
    }

    function setArrival(date: Date) {
        vm.item.Arrival = date;
        vm.arrival.mon = (date.getMonth() + 1).toString();
        if (vm.arrival.mon.length == 1) vm.arrival.mon = '0' + vm.arrival.mon;
        vm.arrival.day = date.getDate().toString();
        if (vm.arrival.day.length == 1) vm.arrival.day = '0' + vm.arrival.day;
        vm.arrival.week = weekday[date.getDay()];
    }

    function setDeparture(date: Date) {
        vm.item.Departure = date;
        vm.departure.mon = (date.getMonth() + 1).toString();
        if (vm.departure.mon.length == 1) vm.departure.mon = '0' + vm.departure.mon;
        vm.departure.day = date.getDate().toString();
        if (vm.departure.day.length == 1) vm.departure.day = '0' + vm.departure.day;
        vm.departure.week = weekday[date.getDay()];
        vm.departure.days = parseInt(((vm.item.Departure - vm.item.Arrival) / 1000 / 60 / 60 / 24).toString());
        angular
    }

    function addArrival(day: number) {
        var dt = vm.item.Arrival;
        if (day < 0 && dt <= getDate(0)) return;
        dt.setDate(dt.getDate() + day);
        setArrival(dt);
        //alert(vm.departure.days);
        addDeparture(day);
    }

    function addDeparture(day: number) {
        var dt = vm.item.Departure;
        if (day < 0 && dt <= vm.item.Arrival) return;
        dt.setDate(dt.getDate() + day);
        setDeparture(dt);
    }

    function getDate(day) {
        var dd = new Date();
        dd.setDate(dd.getDate() + day);
        return dd;
    }

    function setAdult(nums) {
        //$('#adult').val(nums);
        vm.item.adult = nums;
    }

    function getVerifyCode() {
        bookingService.getVerifyCode()
            .then(d => {             
                //alert(JSON.stringify(d.data.VerifyCode))
                if (d.data.VerifyCode != null) {
                    vm.code = d.data.VerifyCode;
                    //return d.data.VerifyCode;
                }
                else {
                    toastr.error("获取失败");
                }
            })
    }

    function dateQuery() {
        alert(JSON.stringify(vm.VerifyCode));
        alert(JSON.stringify(vm.code));
        if (vm.VerifyCode == vm.code) {
            vm.step = 2;
            setArrival(getDate(0));
            setDeparture(getDate(1));

            $('#datepicker-inline').datepicker({
                todayHighlight: true,
                language: "zh-CN",
                //orientation: "bottom",
                startDate: getDate(0),
                endDate: getDate(60)
            });
        }
        else {
            alert("验证码错误!");
        }
    }

    function roomQuery() {
        // alert(JSON.stringify(vm.item));
        bookingService.getRoomTypes(vm.item)
            .then(d => {
                //alert(JSON.stringify(d.data));
                if (d.data.length > 0) {
                    vm.step = 3;
                    App.App.scrollTop();
                    vm.roomtypes = d.data;
                } else {
                    $modal({
                        title: "无可用房间",
                        content: "抱歉，在您选择的日期内，房间已售罄。请您改变行程。",
                        show: true
                    });
                }

                // $scope.$apply();
            });
    }

    function backQuery() {
        vm.step = 2;
        App.App.scrollTop();
    }

    function booking(roomtype) {
        vm.step = 4;
        App.App.scrollTop();
        vm.item.RoomTypeId = roomtype.Id;
        vm.item.RoomType = roomtype;
        vm.item.Rate = roomtype.Rate;
    }

    function selectArrival() {
        vm.selectDateTitle = "入住日期";
        $("#selectDateModal").modal("show");
    }

    function selectDeparture() {
        vm.selectDateTitle = "离店日期";
        $("#selectDateModal").modal("show");
    }

    function selectedDate() {
        $("#selectDateModal").modal("hide");
    }

    // 保存预定
    function subimtResv() {
        $("#subimt-resv").addClass("disabled");
        //alert(JSON.stringify(vm.item));
        bookingService.postReservation(vm.item)  
            .then(d => {
                //alert(JSON.stringify(d.data.Data))
                vm.resvnum = d.data.Data;
                vm.step = 5;
                $("#subimt-resv").removeClass("disabled");
                App.App.scrollTop();
            });
    }

    function bookingNext() {
        vm.step = 2;
        App.App.scrollTop();

    }
} 