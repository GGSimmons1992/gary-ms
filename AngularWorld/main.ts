import {platformBrowserDynamic} from "@angular/platform-browser-dynamic";
import { StartupModule } from "./startup/startup.module";


platformBrowserDynamic()
.bootstrapModule(StartupModule)
.catch((err)=>console.log(err))
