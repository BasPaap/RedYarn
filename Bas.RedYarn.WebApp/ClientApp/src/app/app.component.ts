import { Component, HostListener, ViewChild } from '@angular/core';
import { UserInteractionService } from './services/user-interaction.service';
import { SettingsService } from './services/settings.service';
import { Router, NavigationEnd, NavigationStart } from '@angular/router';
import { MatSidenav } from '@angular/material';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'RedYarn';

  @ViewChild(MatSidenav) sideNav: MatSidenav;

  constructor(private userInteractionService: UserInteractionService, private router: Router) {

    router.events.subscribe(event => {
      // If we are navigating to a diagram, open the sidenav.
      if (event instanceof NavigationEnd && event.urlAfterRedirects.startsWith("/diagram/")) {
        this.sideNav.open();
      }

      // If we are looking at a diagram, but are navigating away, close the sidenav.
      if (event instanceof NavigationStart && this.router.url.startsWith("/diagram/")) {
        this.sideNav.close();
      }
    });
  }

  @HostListener('mousedown') onMouseDown() {
    this.userInteractionService.onMouseDown();
  }

  @HostListener('mouseup') onMouseUp() {
    this.userInteractionService.onMouseUp;
  }

  @HostListener('mousemove', ['$event.clientX', '$event.clientY', '$event.buttons'])
  onMouseMove(x: number, y: number, buttons: number) {
    this.userInteractionService.onMouseMove(x, y, buttons);
  }

  @HostListener('keyup', ['$event.key', '$event.altKey'])
  onkeyup(key: string, altKey: boolean) {
    this.userInteractionService.onKeyUp(key, altKey);
  }
}
