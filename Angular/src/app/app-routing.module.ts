import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CategoryComponent } from './client/category/category.component';
import { CreateCategoryComponent } from './client/category/create-category/create-category.component';
import { ClientComponent } from './client/client.component';
import { CreatePostComponent } from './client/post/create-post/create-post.component';
import { PostComponent } from './client/post/post.component';
import { CreateTagComponent } from './client/tag/create-tag/create-tag.component';
import { TagComponent } from './client/tag/tag.component';
import { LoginComponent } from './user/login/login.component';
import { PasswordComponent } from './user/password/password.component';
import { RegisterComponent } from './user/register/register.component';
import { UserComponent } from './user/user.component';
const routes: Routes = [
  {
    path: 'user',
    component: UserComponent,
    children: [
      { path: 'login', component: LoginComponent },
      { path: 'register', component: RegisterComponent },
      { path: 'password', component: PasswordComponent },
    ],
  },
  {
    path: '',
    component: ClientComponent,
    children: [
      { path: 'post', component: PostComponent },
      {
        path: 'category',
        component: CategoryComponent,
      },
      { path: 'tag', component: TagComponent },
      { path: 'category/create', component: CreateCategoryComponent },
      { path: 'tag/create', component: CreateTagComponent },
      { path: 'post/create', component: CreatePostComponent },
    ],
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
