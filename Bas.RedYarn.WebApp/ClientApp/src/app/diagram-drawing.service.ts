import { Injectable } from '@angular/core';
import { SettingsService } from './settings.service';
import { style } from '@angular/animations';

class Drawable {
  public draw(context: any) { }
}

class Arrow extends Drawable {
  fromX: number;
  fromY: number;
  toX: number;
  toY: number;
  lineWidth: number;
  style: string;

  public draw(context: any) {
    context.strokeStyle = this.style;
    context.beginPath();
    context.moveTo(this.fromX, this.fromY);
    context.lineTo(this.toX, this.toY);
    context.stroke();
  }
}

@Injectable({
  providedIn: 'root'
})
export class DiagramDrawingService {

  private foregroundDrawables: Drawable[] = [];
  private backgroundDrawables: Drawable[] = [];

  constructor(private settingsService: SettingsService) { }

  public drawNewRelationshipArrow(fromX: number, fromY: number, toX: number, toY: number) {
    let arrow = new Arrow();
    arrow.fromX = fromX;
    arrow.fromY = fromY;
    arrow.toX = toX;
    arrow.toY = toY;
    arrow.lineWidth = this.settingsService.settings.ui.newRelationship.arrow.lineWidth;
    arrow.style = this.settingsService.settings.ui.newRelationship.arrow.style;
    this.backgroundDrawables.push(arrow);
    console.log("HOTSPOT!");
  }

  public onDrawBackgroundUI(context: any) {
    for (var i = 0; i < this.backgroundDrawables.length; i++) {
      this.backgroundDrawables.pop().draw(context);
      console.log("drawing");
    }
 
  }

  public onDrawForegroundUI(context: any) {
    for (var i = 0; i < this.foregroundDrawables.length; i++) {
      this.foregroundDrawables.pop().draw(context);
    }


    //let top = 0 - (50 / 2.0) - this.settingsService.settings.ui.newRelationship.activationZoneWidth;
    //let bottom = 0 + (50 / 2.0) + this.settingsService.settings.ui.newRelationship.activationZoneWidth;
    //let left = 0 - (50 / 2.0)- this.settingsService.settings.ui.newRelationship.activationZoneWidth;
    //let right = 0 + (50 / 2.0) + this.settingsService.settings.ui.newRelationship.activationZoneWidth;
    
    //console.log(left, top);
    //context.strokeStyle = "#ff0000";
    //context.rect(left, top, right-left, bottom-top);
    //context.stroke();
  }
}
