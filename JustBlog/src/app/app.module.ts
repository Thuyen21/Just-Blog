import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { UserComponent } from './user/user.component';
import { ClientComponent } from './client/client.component';
import { LoginComponent } from './user/login/login.component';
import { RegisterComponent } from './user/register/register.component';
import { PasswordComponent } from './user/password/password.component';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, FormGroup } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { PostComponent } from './client/post/post.component';
import { CategoryComponent } from './client/category/category.component';
import { TagComponent } from './client/tag/tag.component';
import { CreateCategoryComponent } from './client/category/create-category/create-category.component';
import { CreateTagComponent } from './client/tag/create-tag/create-tag.component';
import { CreatePostComponent } from './client/post/create-post/create-post.component';

@NgModule({
  declarations: [
    AppComponent,
    UserComponent,
    ClientComponent,
    LoginComponent,
    RegisterComponent,
    PasswordComponent,
    PostComponent,
    CategoryComponent,
    TagComponent,
    CreateCategoryComponent,
    CreateTagComponent,
    CreatePostComponent,
    
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
