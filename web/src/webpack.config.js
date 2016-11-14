/*{
    entry: {
        app: 'app/main.ts'
    },
    output: {
        filename: 'app.js'
    },
    loaders: [
        {
            test: /\.ts$/,
            loaders: 'ts'
        },
        {
            test: /\.css$/,
            loaders: 'style!css'
        }
    ],
        plugins: [
            new webpack.optimize.UglifyJsPlugin()
        ]
}
*/
module.exports = require('./config/webpack.prod.js');