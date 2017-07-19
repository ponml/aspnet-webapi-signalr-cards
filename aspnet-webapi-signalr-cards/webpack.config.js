/// <binding AfterBuild='Run - Development' />
const path = require('path');

module.exports = {
	entry:  './index.js',		
	output: {
		path: path.resolve(__dirname, 'packed'),
		filename: '[name].bundle.js'
	},
	devtool: 'eval-source-map',
	module: {
		loaders: [
				{ test: /\.js$/, exclude: /node_modules/, loader: "babel-loader" }
		]
    }

}