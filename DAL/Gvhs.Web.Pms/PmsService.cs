using System;
using System.Collections.Generic;
using System.Net;
using Gvhs.Web.Pms.DataContracts;
using Gvhs.Web.DataContracts;

namespace Gvhs.Web.Pms
{
    public class PmsService : IPmsService
    {
        private readonly string _apiUrl;

        private Cookie _cookie;

        public PmsService(string apiUrl)
        {
            _apiUrl = apiUrl;
        }


        private Cookie GetCookie()
        {
            if (_cookie == null)
            {
            var url = _apiUrl + "home/login?user=100&password=100";
            _cookie = WebCookieHelper.GetCookie(url);
            }
            return _cookie;
        }
        //创建订单
        public OperatorResult CreateReservation(Reservation entity)
        {
            var url = _apiUrl + "api/Reservations";
            return WebCookieHelper.PostApi<OperatorResult, Reservation>(url, entity, GetCookie());
        }

        public Reservation GetReservation(string resvCode)
        {
            var url = _apiUrl + "api/Reservations/" + resvCode;
            return WebCookieHelper.GetApi<Reservation>(url,  GetCookie());
        }

        public List<RoomType> GetRoomTypes(DateTime arrival, DateTime departure, string rateCode)
        {
            var url = _apiUrl + "api/RoomTypes?arrival={0}&departure={1}&ratecode={2}";
            url = string.Format(url, arrival.ToString("yyyy-MM-dd"),
                                    departure.ToString("yyyy-MM-dd"), rateCode);
            return WebCookieHelper.GetApi<List<RoomType>>(url, GetCookie());
        }

        public OperatorResult UpdateReservation(string resvCode, Reservation entity)
        {
            throw new NotImplementedException();
        }

        public OperatorResult CancelReservation(string resvNum)
        {
            var url = _apiUrl + "api/MyReservations/CancelReservation?resvNum={0}";
            url = string.Format(url, resvNum);
            return WebCookieHelper.GetApi<OperatorResult>(url, GetCookie());
        }

        public Guest GetGuest(string guestCode)
        {
            throw new NotImplementedException();
        }

        public OperatorResult CreateGuest(Guest entity)
        {
            var url = _apiUrl + "api/Guests";
            return WebCookieHelper.PostApi<OperatorResult,Guest>(url,entity, GetCookie());
        }

        public Manager GetData()
        {
            var url = _apiUrl + "api/Managers/GetData";
            var result = WebCookieHelper.GetApi<Manager>(url, GetCookie());
            return result;
        }

        public List<RoomView> GetRoomViews()
        {
            var url = _apiUrl + "api/Managers/GetRoomViews";
            var result = WebCookieHelper.GetApi<List<RoomView>>(url, GetCookie());
            return result;
        }

        public RealtimeStatistic GetRealtimeStatistic()
        {
            var url = _apiUrl + "api/Managers/GetRealtimeStatistic";
            var result = WebCookieHelper.GetApi<RealtimeStatistic>(url, GetCookie());
            return result;
        }

        public Room GetRoom(string guestCode)
        {
            throw new NotImplementedException();
        }

        public RoomView GetRoomViewByRmNum(string rmNum)
        {
            var url = _apiUrl + "api/Managers/GetRoomViewByRmNum?rmNum={0}";
            url = string.Format(url,rmNum);
            var result = WebCookieHelper.GetApi<RoomView>(url, GetCookie());
            return result;
        }

        public List<MyReservation> GetReservationByGuest(string guestCode)
        {
            var url = _apiUrl + "api/MyReservations/GetReservationByGuest?guestCode={0}";
            url = string.Format(url, guestCode);
            var result = WebCookieHelper.GetApi<List<MyReservation>>(url, GetCookie());
            return result;
        }

        public MyReservation GetResvByResvNum(string resvNum)
        {
            var url = _apiUrl + "api/MyReservations/GetResvByResvNum?resvNum={0}";
            url = string.Format(url, resvNum);
            var result = WebCookieHelper.GetApi<MyReservation>(url, GetCookie());
            return result;
        }
    }
}
