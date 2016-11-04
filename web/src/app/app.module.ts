import { NgModule }      from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppComponent }   from './app.component';
import { FormsModule }   from '@angular/forms';
import { HttpModule }    from '@angular/http';
import {DataService} from './app.data.service';
import { Configuration } from './app.constans';
@NgModule({
  imports:      [ BrowserModule, FormsModule, HttpModule ],
  declarations: [ AppComponent ],
  bootstrap:    [ AppComponent],
  providers:[DataService,Configuration]
})
export class AppModule { }