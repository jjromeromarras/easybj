import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './component/home/home.component';
import { ModuleWithProviders } from '@angular/core';

const routes: Routes = [
    { path: '', component: HomeComponent },
];

export const APP_ROUTER = RouterModule.forRoot(routes);
