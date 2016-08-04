/*
    webpack 配置文件
    ts支持
*/
var webpack = require('webpack');
var path = require('path');

var outPath = './wwwroot/';

module.exports = {
    entry: {
       /* 'css': './src/css.ts',*/
        'app': './src/main.ts',
        'booking': './src/booking/booking.vendor.ts',
        'vendor': './src/vendor.ts'
    },
    output: {
        path: outPath + "weixinsrc/js",
        filename: "[name].js"
    },
    plugins: [
      new webpack.ProvidePlugin({
            $: "jquery",
            jQuery: "jquery",
            "window.jQuery": "jquery"
        }), /* 将类库公布到外部 */
      new webpack.optimize.CommonsChunkPlugin('vendor', 'vendor.js'),
      new webpack.optimize.UglifyJsPlugin({
                  compress: {
                      warnings: false
                  }
        })
    ],

    resolve: {
        extensions: ['', '.ts', '.js']
    },

    externals: {
        // require("jquery") is external and available
        //  on the global var jQuery
        //"jquery": "jQuery", // 如果在index中加载了jquery则这里可以直接引用，将全局jQuery引用进来
        "pace": "Pace"
    },

    module: {
        loaders: [
          { test: /\.ts$/, loader: 'ts-loader' },
          { test: /\.less$/, loader: 'style-loader!css-loader!less-loader' },
          { test: /\.css$/, loader: 'style-loader!css-lader' }
        ],
        noParse: [path.join(__dirname, 'node_modules', 'bundles', './src')]
    }
};
