'use strict';
let path = require('path');

module.exports = {
  entry: require('./webpack/entry'),

  context: path.join(process.cwd(), 'src'),

  output: require('./webpack/output.prod'),

  module: require('./webpack/module'),

  plugins: require('./webpack/plugins.prod'),

  resolve: require('./webpack/resolve'),

  devServer: require('./webpack/dev-server'),

  stats: 'errors-only',

  devtool: 'source-map'
};
