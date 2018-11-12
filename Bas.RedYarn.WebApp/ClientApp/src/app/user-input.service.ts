import { Injectable } from '@angular/core';

export interface MouseState {
  isButtonDown: boolean,
  xCoordinate: number,
  yCoordinate: number
}

@Injectable({
  providedIn: 'root'
})
export class UserInputService {

  private mouseState: MouseState = {
    isButtonDown: false,
    xCoordinate: 0,
    yCoordinate: 0
  };

  constructor() { }

  public onMouseUp() {
    this.mouseState.isButtonDown = false;
  }

  public onMouseDown() {
    this.mouseState.isButtonDown = true;
  }

  public onMouseMove(x: number, y: number) {
    this.mouseState.xCoordinate = x;
    this.mouseState.yCoordinate = y;    
  }
}
