'use strict';

let path = require('path');

module.exports = {
  alias: {
    globalize$: path.resolve(process.cwd(), 'node_modules/globalize/dist/globalize.js'),
    globalize: path.resolve(process.cwd(), 'node_modules/globalize/dist/globalize'),
    cldr$: path.resolve(process.cwd(), 'node_modules/cldrjs/dist/cldr.js'),
    cldr: path.resolve(process.cwd(), 'node_modules/cldrjs/dist/cldr')
  },
  modules: [
    'node_modules',
    path.resolve(process.cwd(), 'src')

  ],
  extensions: ['.ts', '.js', 'json']
};