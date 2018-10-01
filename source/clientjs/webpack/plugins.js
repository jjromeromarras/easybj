'use strict';

let webpack = require('webpack');
let CopyWebpackPlugin = require('copy-webpack-plugin');
let ExtractTextPlugin = require('extract-text-webpack-plugin');
let path = require('path');
var HtmlWebpackPlugin = require('html-webpack-plugin');


module.exports = [

  new webpack.ProgressPlugin(),
  new webpack.ContextReplacementPlugin(
    // The (\\|\/) piece accounts for path separators in *nix and Windows
    /angular(\\|\/)core(\\|\/)@angular/,
    path.join(process.cwd(), 'src')
  ),

  new CopyWebpackPlugin([
    { from: 'index.html' },
    { from: 'script', to: 'script' },
    { from: '../config/main.dev.js', to: 'main.js' },
    { from: '../node_modules/core-js/client/shim.min.js', to: 'node_modules/core-js/client/shim.min.js' },
    { from: '../node_modules/jquery/dist/jquery.js', to: 'node_modules/jquery/dist/jquery.js' },
    { from: '../node_modules/reflect-metadata/Reflect.js', to: 'node_modules/reflect-metadata/Reflect.js' },
    { from: '../node_modules/devextreme/dist/js/dx.all.js', to: 'node_modules/devextreme/dist/js/dx.all.js' },
    { from: '../node_modules/devextreme/dist/css/dx.common.css', to: 'node_modules/devextreme/dist/css/dx.common.css' },
    { from: '../node_modules/devextreme/dist/css/dx.light.css', to: 'node_modules/devextreme/dist/css/dx.light.css' },
    { from: '../node_modules/devextreme/dist/css/icons/dxicons.ttf', to: 'node_modules/devextreme/dist/css/icons/dxicons.ttf' },
    { from: '../node_modules/devextreme/dist/css/icons/dxicons.woff', to: 'node_modules/devextreme/dist/css/icons/dxicons.woff' },
    { from: '../node_modules/core-js/client/shim.min.js.map', to: 'node_modules/core-js/client/shim.min.js.map' },
    { from: '../node_modules/reflect-metadata/Reflect.js.map', to: 'node_modules/reflect-metadata/Reflect.js.map' },
    { from: '../node_modules/ng-pick-datetime/assets/style/picker.min.css', to: 'node_modules/ng-pick-datetime/assets/style/picker.min.css' },
    { from: '../node_modules/ng-pick-datetime/assets/font/*', to: 'node_modules/ng-pick-datetime/assets/font/*' },
    { from: 'ApplicationResources/img', to: 'ApplicationResources/img' },
    { from: 'Content/style.css', to: 'Content/style.css' },
    { from: 'Content/main.css', to: 'Content/main.css' },
    { from: 'Content/bootstrap.min.css', to: 'Content/bootstrap.min.css' },
    { from: 'Content/login.css', to: 'Content/login.css' }
  ]),
  new ExtractTextPlugin('style.bundle.css'),

  new webpack.optimize.CommonsChunkPlugin({
    name: ['polyfill'],
    minChunks: 1
  }),

  new webpack.ProvidePlugin({
    $: "jquery",
    jQuery: "jquery",
    jquery: "jquery",
    "window.$": "jquery"
  }),

  new HtmlWebpackPlugin({
    template: 'index.html'
  }),
  
];
