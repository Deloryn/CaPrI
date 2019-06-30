const path = require('path');
const MiniCssExtractPlugin = require('mini-css-extract-plugin');
const VueLoaderPlugin = require('vue-loader/lib/plugin');
const ForkTsCheckerWebpackPlugin = require('fork-ts-checker-webpack-plugin');


const vueConfig = {
    mode: 'development',
    entry: {
        app: path.resolve(__dirname, 'src/app.ts'),
    },
    target: 'web',
    output: {
        path: path.resolve(__dirname, 'wwwroot'),
        filename: 'js/[name].js',
        publicPath: '/'
    },
    devtool: 'source-map',
    node: {
        __dirname: false
    },
    module: {
        rules: [
            {
                test: /\.tsx?$/,
                loader: 'ts-loader',
                options: {
                    transpileOnly: true,
                    appendTsSuffixTo: [/\.vue$/]
                }
            },
            {
                test: /\.node$/,
                loader: 'node-loader'
            },
            {
                test: /\.(png|svg|jpg|gif)$/,
                use: [{
                    loader: 'file-loader',
                    options: {
                        outputPath: 'images',
                        emitFile: true
                    }
                }]
            },
            {
                test: /\.(ttf|woff|woff2|eot)$/,
                use: [{
                    loader: 'file-loader',
                    options: {
                        outputPath: 'fonts',
                        emitFile: true
                    }
                }]
            },
            {
                test: /\.scss$/,
                use: [{
                    loader: MiniCssExtractPlugin.loader,
                    options: {
                        hmr: process.env.NODE_ENV === 'development'
                    }
                }, {
                    loader: "css-loader"
                }, {
                    loader: "sass-loader"
                }]
            },
            {
                test: /\.vue$/,
                loader: 'vue-loader',
                options: {
                    loaders: { js: 'ts-loader', },
                    hotReload: process.env.NODE_ENV === 'development'
                }
            }
        
        ]
    },
    resolve: {
        extensions: ['.ts', '.js', '.vue', '.json', '.tsx'],
        alias: {
            'vue': 'vue/dist/vue.esm.js',
            '@src': path.resolve(__dirname, 'src')
        }
    },
    plugins: [
        new ForkTsCheckerWebpackPlugin({
            workers: 2,
            tslint: true,
            vue: true
        }),
        new VueLoaderPlugin(),
        new MiniCssExtractPlugin({
            filename: 'css/[name].css'
        })
    ]
}

if (process.env.NODE_ENV === 'production') {
    vueConfig.mode = 'production';
    delete vueConfig.devtool;

    vueConfig.resolve.alias.vue = "vue/dist/vue.runtime.min.js";
}

module.exports = vueConfig;