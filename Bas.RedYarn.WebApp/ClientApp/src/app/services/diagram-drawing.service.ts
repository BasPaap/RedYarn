import { Injectable } from '@angular/core';
import { SettingsService } from './settings.service';

export class Drawable {
  z: number;
  public draw(context: any) { }
}

export class DrawableIcon extends Drawable {
  x: number;
  y: number;

  constructor(xPosition: number, yPosition: number) {
    super();

    this.x = xPosition;
    this.y = yPosition;
  }
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

export class BookIcon extends DrawableIcon {
  constructor(xPosition: number, yPosition: number) {
    super(xPosition, yPosition);
  }

  public draw(context: any) {
      context.save(); // Save the context so that we can restore it to the default state after drawing the icon.
      context.translate(this.x, this.y); // Translate everything to the location where we want to draw the icon.

      context.moveTo(0, 0);
      context.lineTo(40, 0);
      context.lineTo(40, 30);
      context.lineTo(0, 30);
      context.closePath();
      context.clip();

      context.lineCap = 'butt';
      context.lineJoin = 'miter';
      context.miterLimit = 4;
      context.fillStyle = "#ffffff";
      context.strokeStyle = "#0000aa";
      context.lineWidth = 1.5;

      context.beginPath();
      context.moveTo(2.526, 5.181);
      context.lineTo(4.791, 5.065);
      context.lineTo(6.836, 1.325);
      context.lineTo(18.229, 2.215);
      context.lineTo(19.981, 4.709);
      context.lineTo(22.464, 1.681);
      context.lineTo(32.981, 1.859);
      context.lineTo(35.025, 5.065);
      context.lineTo(37.801, 4.887);
      context.lineTo(39.407, 28.04);
      context.bezierCurveTo(39.48, 28.157, 0.481, 27.979, 0.481, 28.157);
      context.fill();
      context.stroke();

      context.fillStyle = "#0000aa";
      context.strokeStyle = "#0000aa";
      context.lineWidth = 0.1;
      
      context.beginPath();
      context.moveTo(25.53, 0.015);
      context.bezierCurveTo(25.461, 0.024, 25.172, 0.055, 24.891, 0.082);
      context.bezierCurveTo(24.61, 0.109, 24.15, 0.175, 23.865, 0.233);
      context.bezierCurveTo(22.273, 0.563, 21.287, 1.097, 20.487, 2.077);
      context.bezierCurveTo(20.294, 2.312, 20.093, 2.575, 20.042, 2.66);
      context.lineTo(19.943, 2.816);
      context.lineTo(19.848, 2.66);
      context.bezierCurveTo(19.469, 2.05, 18.662, 1.28, 18.041, 0.932);
      context.bezierCurveTo(16.252, -0.074, 12.958, -0.252, 8.953, 0.438);
      context.bezierCurveTo(8.223, 0.563, 6.693, 0.888, 6.2, 1.021);
      context.lineTo(5.981, 1.079);
      context.lineTo(5.331, 2.215);
      context.bezierCurveTo(4.809, 3.123, 4.663, 3.354, 4.579, 3.377);
      context.bezierCurveTo(4.524, 3.394, 3.863, 3.439, 3.111, 3.479);
      context.bezierCurveTo(1.464, 3.568, 1.439, 3.568, 1.395, 3.697);
      context.bezierCurveTo(1.377, 3.751, 1.304, 4.908, 1.23, 6.266);
      context.bezierCurveTo(1.157, 7.624, 1.059, 9.45, 1.011, 10.318);
      context.bezierCurveTo(0.96, 11.186, 0.832, 13.559, 0.719, 15.594);
      context.bezierCurveTo(0.61, 17.624, 0.493, 19.721, 0.464, 20.247);
      context.bezierCurveTo(0.435, 20.772, 0.343, 22.406, 0.263, 23.875);
      context.bezierCurveTo(0.183, 25.345, 0.11, 26.676, 0.099, 26.836);
      context.bezierCurveTo(0.091, 26.996, 0.062, 27.455, 0.04, 27.86);
      context.lineTo(0, 28.595);
      context.lineTo(0.212, 29.276);
      context.bezierCurveTo(0.332, 29.654, 0.453, 29.975, 0.482, 29.997);
      context.bezierCurveTo(0.511, 30.015, 1.607, 29.944, 2.91, 29.837);
      context.bezierCurveTo(6.945, 29.512, 7.996, 29.427, 11.126, 29.174);
      context.bezierCurveTo(12.794, 29.04, 14.689, 28.884, 15.343, 28.831);
      context.lineTo(16.529, 28.737);
      context.lineTo(17.077, 28.964);
      context.bezierCurveTo(18.092, 29.387, 18.859, 29.601, 19.67, 29.69);
      context.bezierCurveTo(20.732, 29.806, 21.937, 29.548, 23.058, 28.964);
      context.bezierCurveTo(23.474, 28.746, 23.522, 28.733, 23.777, 28.742);
      context.bezierCurveTo(23.927, 28.746, 27.534, 29.013, 31.788, 29.334);
      context.bezierCurveTo(38.105, 29.806, 39.536, 29.904, 39.569, 29.855);
      context.bezierCurveTo(39.595, 29.824, 39.701, 29.499, 39.806, 29.134);
      context.lineTo(40, 28.475);
      context.lineTo(39.774, 24.57);
      context.bezierCurveTo(39.376, 17.682, 38.978, 10.794, 38.762, 7.045);
      context.bezierCurveTo(38.616, 4.459, 38.539, 3.377, 38.507, 3.332);
      context.bezierCurveTo(38.47, 3.283, 38.204, 3.256, 37.335, 3.212);
      context.bezierCurveTo(36.717, 3.181, 36.031, 3.145, 35.808, 3.132);
      context.bezierCurveTo(35.589, 3.118, 35.341, 3.105, 35.257, 3.105);
      context.lineTo(35.111, 3.105);
      context.lineTo(34.479, 2.041);
      context.bezierCurveTo(33.979, 1.19, 33.833, 0.968, 33.753, 0.95);
      context.bezierCurveTo(32.409, 0.612, 30.499, 0.264, 29.068, 0.095);
      context.bezierCurveTo(28.509, 0.033, 25.862, -0.029, 25.53, 0.015);
      context.closePath();

      context.moveTo(28.597, 2.905);
      context.bezierCurveTo(29.736, 3.029, 31.303, 3.274, 32.234, 3.466);
      context.lineTo(32.456, 3.515);
      context.lineTo(32.482, 4.053);
      context.bezierCurveTo(32.493, 4.352, 32.522, 5.006, 32.54, 5.509);
      context.bezierCurveTo(32.694, 9.459, 32.796, 12.143, 32.814, 12.499);
      context.bezierCurveTo(32.854, 13.43, 32.876, 13.969, 32.979, 16.685);
      context.bezierCurveTo(33.037, 18.239, 33.095, 19.659, 33.106, 19.841);
      context.lineTo(33.128, 20.166);
      context.lineTo(33.008, 20.149);
      context.bezierCurveTo(32.942, 20.135, 32.486, 20.055, 31.993, 19.966);
      context.bezierCurveTo(30.182, 19.641, 29.207, 19.556, 27.136, 19.556);
      context.bezierCurveTo(25.424, 19.556, 25.019, 19.583, 24.106, 19.761);
      context.bezierCurveTo(22.85, 20.002, 21.751, 20.563, 20.867, 21.409);
      context.bezierCurveTo(20.739, 21.529, 20.623, 21.627, 20.601, 21.627);
      context.bezierCurveTo(20.579, 21.627, 20.564, 19.508, 20.557, 15.425);
      context.bezierCurveTo(20.542, 6.355, 20.542, 6.502, 20.593, 6.199);
      context.bezierCurveTo(20.812, 4.966, 21.218, 4.312, 22.105, 3.751);
      context.bezierCurveTo(22.824, 3.296, 23.858, 2.98, 25.092, 2.838);
      context.bezierCurveTo(25.618, 2.78, 27.856, 2.82, 28.597, 2.905);
      context.closePath();

      context.moveTo(15.379, 2.922);
      context.bezierCurveTo(15.916, 3.003, 16.602, 3.185, 17.011, 3.35);
      context.bezierCurveTo(18.249, 3.853, 18.969, 4.677, 19.293, 5.963);
      context.lineTo(19.377, 6.288);
      context.lineTo(19.388, 13.938);
      context.bezierCurveTo(19.396, 20.104, 19.388, 21.582, 19.352, 21.551);
      context.bezierCurveTo(19.326, 21.533, 19.162, 21.4, 18.987, 21.257);
      context.bezierCurveTo(17.983, 20.443, 16.665, 19.935, 14.941, 19.686);
      context.bezierCurveTo(14.266, 19.592, 12.469, 19.556, 11.6, 19.619);
      context.bezierCurveTo(10.366, 19.712, 8.884, 19.899, 7.514, 20.135);
      context.bezierCurveTo(7.171, 20.198, 6.89, 20.238, 6.883, 20.229);
      context.bezierCurveTo(6.875, 20.22, 6.894, 19.565, 6.923, 18.773);
      context.bezierCurveTo(6.956, 17.98, 7.003, 16.627, 7.036, 15.772);
      context.bezierCurveTo(7.065, 14.913, 7.098, 14.004, 7.109, 13.746);
      context.bezierCurveTo(7.157, 12.553, 7.168, 12.201, 7.219, 10.785);
      context.bezierCurveTo(7.248, 9.953, 7.306, 8.399, 7.346, 7.335);
      context.bezierCurveTo(7.387, 6.271, 7.427, 5.037, 7.441, 4.597);
      context.bezierCurveTo(7.456, 4.156, 7.478, 3.755, 7.496, 3.702);
      context.bezierCurveTo(7.518, 3.63, 7.573, 3.599, 7.774, 3.559);
      context.bezierCurveTo(7.909, 3.528, 8.259, 3.457, 8.551, 3.394);
      context.bezierCurveTo(9.552, 3.185, 10.738, 3.007, 11.71, 2.927);
      context.bezierCurveTo(12.031, 2.9, 12.367, 2.873, 12.458, 2.865);
      context.bezierCurveTo(12.812, 2.829, 15.051, 2.878, 15.379, 2.922);
      context.closePath();

      context.moveTo(5.941, 5.897);
      context.bezierCurveTo(5.93, 6.115, 5.89, 7.108, 5.849, 8.114);
      context.bezierCurveTo(5.809, 9.116, 5.751, 10.518, 5.722, 11.231);
      context.bezierCurveTo(5.656, 12.762, 5.543, 15.594, 5.466, 17.486);
      context.bezierCurveTo(5.408, 18.92, 5.389, 19.347, 5.353, 20.135);
      context.lineTo(5.327, 20.621);
      context.lineTo(4.78, 21.627);
      context.bezierCurveTo(4.48, 22.179, 4.217, 22.646, 4.199, 22.673);
      context.bezierCurveTo(4.162, 22.713, 4.177, 21.934, 4.225, 21.07);
      context.bezierCurveTo(4.236, 20.897, 4.268, 20.198, 4.298, 19.512);
      context.bezierCurveTo(4.327, 18.826, 4.385, 17.522, 4.425, 16.618);
      context.bezierCurveTo(4.466, 15.71, 4.531, 14.209, 4.571, 13.279);
      context.bezierCurveTo(4.612, 12.348, 4.67, 11.026, 4.699, 10.34);
      context.bezierCurveTo(4.728, 9.654, 4.761, 8.933, 4.772, 8.737);
      context.bezierCurveTo(4.78, 8.541, 4.801, 8.15, 4.812, 7.869);
      context.lineTo(4.838, 7.357);
      context.lineTo(5.389, 6.435);
      context.bezierCurveTo(5.692, 5.923, 5.944, 5.509, 5.952, 5.509);
      context.bezierCurveTo(5.959, 5.509, 5.955, 5.683, 5.941, 5.897);
      context.closePath();

      context.moveTo(34.581, 6.502);
      context.lineTo(35.126, 7.428);
      context.lineTo(35.147, 7.838);
      context.bezierCurveTo(35.158, 8.065, 35.202, 8.96, 35.242, 9.828);
      context.bezierCurveTo(35.283, 10.696, 35.348, 12.108, 35.388, 12.967);
      context.bezierCurveTo(35.604, 17.544, 35.691, 19.365, 35.735, 20.38);
      context.bezierCurveTo(35.746, 20.612, 35.772, 21.101, 35.79, 21.471);
      context.bezierCurveTo(35.808, 21.836, 35.827, 22.246, 35.827, 22.379);
      context.lineTo(35.827, 22.62);
      context.lineTo(35.228, 21.565);
      context.lineTo(34.629, 20.514);
      context.lineTo(34.607, 20.122);
      context.bezierCurveTo(34.592, 19.908, 34.541, 18.773, 34.494, 17.597);
      context.bezierCurveTo(34.443, 16.422, 34.351, 14.338, 34.293, 12.967);
      context.bezierCurveTo(34.231, 11.596, 34.151, 9.712, 34.11, 8.782);
      context.bezierCurveTo(34.034, 6.979, 34.016, 6.578, 33.979, 5.91);
      context.bezierCurveTo(33.964, 5.612, 33.968, 5.5, 33.997, 5.532);
      context.bezierCurveTo(34.019, 5.558, 34.278, 5.995, 34.581, 6.502);
      context.closePath();

      context.moveTo(37.156, 6.257);
      context.bezierCurveTo(37.167, 6.422, 37.185, 6.725, 37.196, 6.934);
      context.bezierCurveTo(37.207, 7.143, 37.272, 8.394, 37.342, 9.717);
      context.bezierCurveTo(37.47, 12.094, 37.513, 12.945, 37.798, 18.288);
      context.bezierCurveTo(37.879, 19.792, 37.97, 21.498, 37.999, 22.072);
      context.bezierCurveTo(38.028, 22.646, 38.061, 23.27, 38.072, 23.452);
      context.bezierCurveTo(38.083, 23.635, 38.123, 24.405, 38.163, 25.166);
      context.bezierCurveTo(38.204, 25.923, 38.244, 26.694, 38.255, 26.876);
      context.lineTo(38.277, 27.201);
      context.lineTo(37.791, 27.17);
      context.bezierCurveTo(37.524, 27.152, 37.298, 27.13, 37.291, 27.121);
      context.bezierCurveTo(37.283, 27.112, 37.342, 26.827, 37.426, 26.489);
      context.lineTo(37.579, 25.879);
      context.lineTo(37.543, 25.233);
      context.bezierCurveTo(37.524, 24.877, 37.36, 21.703, 37.178, 18.176);
      context.bezierCurveTo(36.995, 14.65, 36.783, 10.496, 36.703, 8.942);
      context.bezierCurveTo(36.623, 7.388, 36.557, 6.075, 36.557, 6.026);
      context.bezierCurveTo(36.557, 5.937, 36.575, 5.932, 36.845, 5.946);
      context.lineTo(37.134, 5.959);
      context.lineTo(37.156, 6.257);

      context.closePath();
      context.moveTo(3.348, 6.564);
      context.bezierCurveTo(3.337, 6.756, 3.286, 7.771, 3.239, 8.826);
      context.bezierCurveTo(3.144, 10.759, 3.056, 12.606, 3.02, 13.301);
      context.bezierCurveTo(2.994, 13.8, 2.822, 17.317, 2.6, 21.983);
      context.bezierCurveTo(2.541, 23.221, 2.483, 24.352, 2.476, 24.499);
      context.bezierCurveTo(2.465, 24.646, 2.446, 25.06, 2.432, 25.416);
      context.lineTo(2.406, 26.066);
      context.lineTo(2.563, 26.631);
      context.bezierCurveTo(2.647, 26.943, 2.709, 27.206, 2.698, 27.219);
      context.bezierCurveTo(2.68, 27.241, 1.749, 27.326, 1.731, 27.308);
      context.bezierCurveTo(1.727, 27.299, 1.822, 25.345, 1.942, 22.958);
      context.bezierCurveTo(2.063, 20.572, 2.22, 17.468, 2.289, 16.061);
      context.bezierCurveTo(2.359, 14.654, 2.424, 13.35, 2.435, 13.167);
      context.bezierCurveTo(2.446, 12.985, 2.519, 11.529, 2.6, 9.939);
      context.bezierCurveTo(2.68, 8.345, 2.753, 6.858, 2.768, 6.631);
      context.lineTo(2.79, 6.222);
      context.lineTo(3.082, 6.222);
      context.lineTo(3.37, 6.222);
      context.lineTo(3.348, 6.564);
      context.closePath();

      context.moveTo(27.867, 22.206);
      context.bezierCurveTo(29.506, 22.299, 30.897, 22.482, 32.84, 22.856);
      context.lineTo(33.669, 23.016);
      context.lineTo(34.107, 23.822);
      context.bezierCurveTo(34.348, 24.267, 34.541, 24.632, 34.538, 24.637);
      context.bezierCurveTo(34.534, 24.646, 33.559, 24.57, 32.376, 24.476);
      context.bezierCurveTo(30.156, 24.298, 26.665, 24.022, 24.234, 23.831);
      context.bezierCurveTo(23.471, 23.773, 22.759, 23.715, 22.653, 23.702);
      context.bezierCurveTo(22.466, 23.684, 22.455, 23.688, 22.251, 23.902);
      context.bezierCurveTo(22.138, 24.022, 21.904, 24.209, 21.733, 24.316);
      context.bezierCurveTo(21.426, 24.512, 20.937, 24.721, 20.9, 24.677);
      context.bezierCurveTo(20.889, 24.663, 20.958, 24.512, 21.053, 24.343);
      context.bezierCurveTo(21.963, 22.727, 24.267, 22.001, 27.867, 22.206);
      context.closePath();

      context.moveTo(14.284, 22.25);
      context.bezierCurveTo(16.376, 22.397, 17.621, 22.851, 18.424, 23.764);
      context.bezierCurveTo(18.629, 23.991, 18.979, 24.579, 18.928, 24.601);
      context.bezierCurveTo(18.87, 24.623, 18.33, 24.352, 18.136, 24.205);
      context.bezierCurveTo(18.034, 24.129, 17.884, 23.987, 17.796, 23.889);
      context.lineTo(17.639, 23.715);
      context.lineTo(17.395, 23.742);
      context.bezierCurveTo(17.26, 23.755, 15.967, 23.866, 14.521, 23.987);
      context.bezierCurveTo(11.44, 24.245, 10.414, 24.329, 7.657, 24.565);
      context.bezierCurveTo(6.532, 24.659, 5.608, 24.73, 5.601, 24.721);
      context.bezierCurveTo(5.586, 24.708, 6.379, 23.199, 6.448, 23.105);
      context.bezierCurveTo(6.503, 23.038, 6.989, 22.931, 8.332, 22.695);
      context.bezierCurveTo(10.625, 22.295, 12.699, 22.139, 14.284, 22.25);
      context.closePath();
      context.fill();
      context.stroke();

      context.restore();
  }
}

export class PuzzlePieceIcon extends DrawableIcon {
  constructor(xPosition: number, yPosition: number) {
    super(xPosition, yPosition);
  }

  public draw(context: any) {
 
      context.save(); // Save the context so that we can restore it to the default state after drawing the icon.
      context.translate(this.x, this.y); // Translate everything to the location where we want to draw the icon.
      
      context.beginPath();
      context.moveTo(0, 0);
      context.lineTo(35, 0);
      context.lineTo(35, 35);
      context.lineTo(0, 35);
      context.closePath();
      context.clip();

      context.strokeStyle = 'rgba(0,0,0,0)';
      context.lineCap = 'butt';
      context.lineJoin = 'miter';
      context.miterLimit = 4;

      context.fillStyle = "#ffffff";
      context.strokeStyle = "#E34234";
      context.lineWidth = 2;
      context.lineCap = "butt";
      context.lineJoin = "miter";
      context.miterLimit = 4;

      context.beginPath();
      context.moveTo(28.251, 2.531);
      context.bezierCurveTo(26.403, 4.378, 27.005, 6.581, 26.001, 7.585);
      context.bezierCurveTo(23.332, 10.254, 17.937, 0, 17.937, 0);
      context.bezierCurveTo(17.937, 0, 12.753, 12.287, 9.055, 8.589);
      context.bezierCurveTo(7.464, 6.999, 8.617, 4.921, 6.852, 3.157);
      context.bezierCurveTo(5.276, 1.581, 3.172, 1.979, 1.688, 3.463);
      context.bezierCurveTo(0.146, 5.005, -0.427, 7.255, 1.236, 8.918);
      context.bezierCurveTo(3.072, 10.754, 5.279, 10.138, 6.277, 11.136);
      context.bezierCurveTo(9.368, 14.227, -0.278, 20.236, -0.278, 20.236);
      context.lineTo(14.516, 35.031);
      context.bezierCurveTo(14.516, 35.031, 24.289, 28.903, 21.194, 25.809);
      context.bezierCurveTo(20.196, 24.811, 17.633, 25.808, 15.797, 23.972);
      context.bezierCurveTo(14.134, 22.309, 14.597, 20.168, 16.124, 18.641);
      context.bezierCurveTo(17.623, 17.142, 19.727, 16.744, 21.304, 18.32);
      context.bezierCurveTo(23.068, 20.084, 21.916, 22.162, 23.506, 23.752);
      context.bezierCurveTo(26.206, 26.452, 30.42, 19.124, 32.714, 16.829);
      context.bezierCurveTo(32.714, 16.829, 25.836, 13.043, 28.531, 10.348);
      context.bezierCurveTo(30.132, 8.747, 32.202, 9.887, 33.977, 8.112);
      context.bezierCurveTo(35.563, 6.526, 35.178, 4.424, 33.689, 2.935);
      context.bezierCurveTo(32.17, 1.416, 29.924, 0.857, 28.251, 2.531);
      context.lineTo(28.251, 2.531);
      context.closePath();
      context.fill();
      context.stroke();

      context.restore();
  }
}

@Injectable({
  providedIn: 'root'
})
export class DiagramDrawingService {

  private foregroundDrawables: Drawable[] = [];
  private backgroundDrawables: Drawable[] = [];
  private readonly iconZ = 10;
  private readonly highlightZ = 5;
  

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
    circle.z = this.highlightZ;
    circle.radius = this.settingsService.settings.ui.characterNode.radius;
    circle.style = this.settingsService.settings.ui.newRelationship.arrow.style;
    circle.lineWidth = this.settingsService.settings.ui.characterNode.borderWidth * this.settingsService.settings.ui.newRelationship.nodeHighlightFactor;
    this.foregroundDrawables.push(circle);
  }

  drawRectangularNodeHighlight(x: number, y: number, width: number, height: number) {
    let rectangle = new Rectangle();
    rectangle.x = x;
    rectangle.y = y;
    rectangle.z = this.highlightZ;
    rectangle.width = width;
    rectangle.height = height;
    rectangle.style = this.settingsService.settings.ui.newRelationship.arrow.style;
    rectangle.lineWidth = this.settingsService.settings.ui.storylineNode.borderWidth * this.settingsService.settings.ui.newRelationship.nodeHighlightFactor;
    this.foregroundDrawables.push(rectangle);
  }

  drawPuzzlePieceIcon(x: number, y: number) {
    let puzzlePieceIcon = new PuzzlePieceIcon(x, y);
    puzzlePieceIcon.z = this.iconZ;
    this.foregroundDrawables.push(puzzlePieceIcon);
  }

  drawBookIcon(x: number, y: number) {
    let bookIcon = new BookIcon(x,y);
    bookIcon.z = this.iconZ;
    this.foregroundDrawables.push(bookIcon);
  }

  public onDrawBackgroundUI(context: any) {
    this.backgroundDrawables = this.backgroundDrawables.sort((d1, d2) => d2.z - d1.z); // sort the array on the z index, descending (because the last items will be popped first)

    while (this.backgroundDrawables.length > 0) {
      this.backgroundDrawables.pop().draw(context);
    }
  }

  public onDrawForegroundUI(context: any) {
    this.foregroundDrawables = this.foregroundDrawables.sort((d1, d2) => d2.z - d1.z); // sort the array on the z index, descending (because the last items will be popped first)

    while (this.foregroundDrawables.length > 0) {
      this.foregroundDrawables.pop().draw(context);
    }
  }
}
