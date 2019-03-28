/// <binding BeforeBuild='default' />
/*
This file is the main entry point for defining Gulp tasks and using Gulp plugins.
Click here to learn more. https://go.microsoft.com/fwlink/?LinkId=518007
*/

const gulp = require('gulp');
const rimraf = require("rimraf");
const merge = require('merge-stream');

// Dependency Dirs
var deps = {
    "jquery": {
        "dist/*": ""
    },
    "flot": {
        "source/*": ""
    }
};

function clean(cb)
{
    return rimraf("wwwroot/lib/", cb);
}

function scripts(cb)
{
    var streams = [];

    for (var prop in deps)
    {
        console.log("Prepping Scripts for: " + prop);
        for (var itemProp in deps[prop])
        {
            streams
                .push(gulp.src("node_modules/" + prop + "/" + itemProp)
                .pipe(gulp.dest("wwwroot/lib/" + prop + "/" + deps[prop][itemProp])));
        }
    }

    return merge(streams);
}

exports.default = gulp.series(clean, scripts);