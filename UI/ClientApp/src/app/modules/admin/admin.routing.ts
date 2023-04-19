import { Routes } from '@angular/router';
import { HotelComponent } from './components/hotel/hotel.component';
import { AdminComponent } from './admin.component';

export const AdminRoutes: Routes = [
    { path: '', component: AdminComponent },
{ path: 'hotel', component: HotelComponent },
    
];
