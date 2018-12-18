import { Directive, ElementRef, Input } from '@angular/core';
import { Drawable, BookIcon, PuzzlePieceIcon } from './services/diagram-drawing.service';
@Directive({
  selector: '[appDrawable]'
})
export class DrawableDirective {

  constructor(private element: ElementRef) { }

  @Input() public set appDrawable(iconName: string) {
    let drawableIcon: Drawable;

   switch (iconName) {
      case "book":
        drawableIcon = new BookIcon(0,2.5);
        break;
      case "puzzlePiece":
        drawableIcon = new PuzzlePieceIcon(2.5, 0);
        break;
      default:
        break;
    }

    if (drawableIcon) {
      drawableIcon.draw(this.element.nativeElement.getContext('2d'));
    }
  }
}
