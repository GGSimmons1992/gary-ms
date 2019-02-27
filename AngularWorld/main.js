"use strict";
exports.__esModule = true;
var platform_browser_dynamic_1 = require("@angular/platform-browser-dynamic");
var startup_module_1 = require("./startup/startup.module");
platform_browser_dynamic_1.platformBrowserDynamic()
    .bootstrapModule(startup_module_1.StartupModule)["catch"](function (err) { return console.log(err); });
