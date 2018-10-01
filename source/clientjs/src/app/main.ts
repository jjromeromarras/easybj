import { enableProdMode } from '@angular/core';
import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';
import { MainModule } from './modules/main.module';

enableProdMode();
platformBrowserDynamic().bootstrapModule(MainModule);