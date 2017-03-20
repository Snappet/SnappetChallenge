﻿// Polyfills
import 'chart.js';
import 'es6-shim';
import 'reflect-metadata';
import 'zone.js';

// import { enableProdMode } from '@angular/core';
import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';

import { AppModule } from './app.module';

// enableProdMode();
platformBrowserDynamic().bootstrapModule(AppModule);
console.info('Application is reloading...');
