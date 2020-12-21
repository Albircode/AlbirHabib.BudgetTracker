import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { UserDetailComponent } from './user-detail/user-detail.component';
import { UserUpdateComponent } from './user-detail/user-update/user-update.component';
import { UsersComponent } from './users/users.component';
const routes: Routes = [
  { path:'', component: UsersComponent,},
  
  { path:'User/:id', component: UserDetailComponent},
  {path: 'User/update:id/', component: UserUpdateComponent, },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
