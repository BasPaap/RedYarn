import { Injectable } from '@angular/core';
import { SettingsService } from './settings.service';
import { style } from '@angular/animations';

class Drawable {
  public draw(context: any) { }
}

class Circle extends Drawable {
  x: number;
  y: number;
  radius: number;
  lineWidth: number;
  style: string;

  public draw(context: any) {
    context.beginPath();
    context.strokeStyle = this.style;
    context.lineWidth = this.lineWidth;
    context.arc(this.x, this.y, this.radius, 0, 2 * Math.PI);
    context.stroke();
  }
}

class Rectangle extends Drawable {
  x: number;
  y: number;
  width: number;
  height: number;
  lineWidth: number;
  style: string;

  public draw(context: any) {
    let cornerRadius = 7.5;

    context.beginPath();
    context.strokeStyle = this.style;
    context.lineWidth = this.lineWidth * 2;
    context.moveTo(this.x + cornerRadius, this.y);
    context.lineTo(this.x + this.width - cornerRadius, this.y);
    context.quadraticCurveTo(this.x + this.width, this.y, this.x + this.width, this.y + cornerRadius);
    context.lineTo(this.x + this.width, this.y + this.height - cornerRadius);
    context.quadraticCurveTo(this.x + this.width, this.y + this.height, this.x + this.width - cornerRadius, this.y + this.height);
    context.lineTo(this.x + cornerRadius, this.y + this.height);
    context.quadraticCurveTo(this.x, this.y + this.height, this.x, this.y + this.height - cornerRadius);
    context.lineTo(this.x, this.y + cornerRadius);
    context.quadraticCurveTo(this.x, this.y, this.x + cornerRadius, this.y);
    context.closePath();
    context.stroke();    
  }
}


class Arrow extends Drawable {
  fromX: number;
  fromY: number;
  toX: number;
  toY: number;
  lineWidth: number;
  style: string;
  headLength: number;

  public draw(context: any) {
    var angle = Math.atan2(this.toY - this.fromY, this.toX - this.fromX);

    //starting path of the arrow from the start square to the end square and drawing the stroke
    context.beginPath();
    context.moveTo(this.fromX, this.fromY);
    context.lineTo(this.toX, this.toY);
    context.strokeStyle = this.style;
    context.lineWidth = this.lineWidth;
    context.stroke();

    //starting a new path from the head of the arrow to one of the sides of the point
    context.beginPath();
    context.moveTo(this.toX, this.toY);
    context.lineTo(this.toX - this.headLength * Math.cos(angle - Math.PI / 7), this.toY - this.headLength * Math.sin(angle - Math.PI / 7));

    //path from the side point of the arrow, to the other side point
    context.lineTo(this.toX - this.headLength * Math.cos(angle + Math.PI / 7), this.toY - this.headLength * Math.sin(angle + Math.PI / 7));

    //path from the side point back to the tip of the arrow, and then again to the opposite side point
    context.lineTo(this.toX, this.toY);
    context.lineTo(this.toX - this.headLength * Math.cos(angle - Math.PI / 7), this.toY - this.headLength * Math.sin(angle - Math.PI / 7));

    //draws the paths created above
    context.strokeStyle = this.style;
    context.lineWidth = this.lineWidth;
    context.stroke();
    context.fillStyle = this.style;
    context.fill();
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
    arrow.headLength = this.settingsService.settings.ui.newRelationship.arrow.headLength;
    this.backgroundDrawables.push(arrow);
  }

  drawCircularNodeHighlight(x: number, y: number) {
    let circle = new Circle();
    circle.x = x;
    circle.y = y;
    circle.radius = this.settingsService.settings.ui.characterNode.radius;
    circle.style = this.settingsService.settings.ui.newRelationship.arrow.style;
    circle.lineWidth = this.settingsService.settings.ui.characterNode.borderWidth;
    this.foregroundDrawables.push(circle);
  }

  drawRectangularNodeHighlight(x: number, y: number, width: number, height: number) {
    let rectangle = new Rectangle();
    rectangle.x = x;
    rectangle.y = y;
    rectangle.width = width;
    rectangle.height = height;
    rectangle.style = this.settingsService.settings.ui.newRelationship.arrow.style;
    rectangle.lineWidth = this.settingsService.settings.ui.storylineNode.borderWidth;
    this.foregroundDrawables.push(rectangle);
  }

  public onDrawBackgroundUI(context: any) {
    for (var i = 0; i < this.backgroundDrawables.length; i++) {
      this.backgroundDrawables.pop().draw(context);
    }
 
  }

  public onDrawForegroundUI(context: any) {
    for (var i = 0; i < this.foregroundDrawables.length; i++) {
      this.foregroundDrawables.pop().draw(context);
    }
  }
}
