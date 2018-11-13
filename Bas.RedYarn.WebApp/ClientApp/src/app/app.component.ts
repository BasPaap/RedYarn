import { Component, HostListener } from '@angular/core';
import { UserInputService } from './user-input.service';
import { SettingsService } from './settings.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'RedYarn';

  constructor(private userInputService: UserInputService, private settingsService: SettingsService) {
    this.settingsService.load();
  }
  
  @HostListener('mousedown') onMouseDown() {
    this.userInputService.onMouseDown();
  }

  @HostListener('mouseup') onMouseUp() {
    this.userInputService.onMouseUp;
  }
  
  @HostListener('mousemove', ['$event.screenX', '$event.screenY'])
  onMouseMove(x: number, y: number) {
    this.userInputService.onMouseMove(x, y);
  }
}
