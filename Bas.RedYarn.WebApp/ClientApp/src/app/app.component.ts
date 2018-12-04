import { Component, HostListener } from '@angular/core';
import { UserInteractionService } from './services/user-interaction.service';
import { SettingsService } from './services/settings.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'RedYarn';

  constructor(private userInteractionService: UserInteractionService, private settingsService: SettingsService) {
    this.settingsService.load();
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
}
