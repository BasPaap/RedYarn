import { Injectable } from '@angular/core';
import { SettingsService } from './settings.service';

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

class BookIcon extends Drawable {
  x: number;
  y: number;

  public draw(context: any) {
    context.save();
    context.translate(this.x, this.y);
    context.beginPath();
    context.moveTo(0, 0);
    context.lineTo(40, 0);
    context.lineTo(40, 40);
    context.lineTo(0, 40);
    context.closePath();
    context.clip();
    context.scale(0.03125, 0.03125);
    context.strokeStyle = 'rgba(0,0,0,0)';
    context.lineCap = 'butt';
    context.lineJoin = 'miter';
    context.miterLimit = 4;
    context.save();
    context.fillStyle = "#3f51b5";
    context.strokeStyle = "rgba(0, 0, 0, 0)";
    context.translate(0, 1280);
    context.scale(0.1, -0.1);
    context.save();
    context.beginPath();
    context.moveTo(8560, 9654);
    context.bezierCurveTo(8541, 9652, 8462, 9645, 8385, 9639);
    context.bezierCurveTo(8308, 9633, 8182, 9618, 8104, 9605);
    context.bezierCurveTo(7668, 9531, 7398, 9411, 7179, 9191);
    context.bezierCurveTo(7126, 9138, 7071, 9079, 7057, 9060);
    context.lineTo(7030, 9025);
    context.lineTo(7004, 9060);
    context.bezierCurveTo(6900, 9197, 6679, 9370, 6509, 9448);
    context.bezierCurveTo(6019, 9674, 5117, 9714, 4020, 9559);
    context.bezierCurveTo(3820, 9531, 3401, 9458, 3266, 9428);
    context.lineTo(3206, 9415);
    context.lineTo(3028, 9160);
    context.bezierCurveTo(2885, 8956, 2845, 8904, 2822, 8899);
    context.bezierCurveTo(2807, 8895, 2626, 8885, 2420, 8876);
    context.bezierCurveTo(1969, 8856, 1962, 8856, 1950, 8827);
    context.bezierCurveTo(1945, 8815, 1925, 8555, 1905, 8250);
    context.bezierCurveTo(1885, 7945, 1858, 7535, 1845, 7340);
    context.bezierCurveTo(1831, 7145, 1796, 6612, 1765, 6155);
    context.bezierCurveTo(1735, 5699, 1703, 5228, 1695, 5110);
    context.bezierCurveTo(1687, 4992, 1662, 4625, 1640, 4295);
    context.bezierCurveTo(1618, 3965, 1598, 3666, 1595, 3630);
    context.bezierCurveTo(1593, 3594, 1585, 3491, 1579, 3400);
    context.lineTo(1568, 3235);
    context.lineTo(1626, 3082);
    context.bezierCurveTo(1659, 2997, 1692, 2925, 1700, 2920);
    context.bezierCurveTo(1708, 2916, 2008, 2932, 2365, 2956);
    context.bezierCurveTo(3470, 3029, 3758, 3048, 4615, 3105);
    context.bezierCurveTo(5072, 3135, 5591, 3170, 5770, 3182);
    context.lineTo(6095, 3203);
    context.lineTo(6245, 3152);
    context.bezierCurveTo(6523, 3057, 6733, 3009, 6955, 2989);
    context.bezierCurveTo(7246, 2963, 7576, 3021, 7883, 3152);
    context.bezierCurveTo(7997, 3201, 8010, 3204, 8080, 3202);
    context.bezierCurveTo(8121, 3201, 9109, 3141, 10274, 3069);
    context.bezierCurveTo(12004, 2963, 12396, 2941, 12405, 2952);
    context.bezierCurveTo(12412, 2959, 12441, 3032, 12470, 3114);
    context.lineTo(12523, 3262);
    context.lineTo(12461, 4139);
    context.bezierCurveTo(12352, 5686, 12243, 7233, 12184, 8075);
    context.bezierCurveTo(12144, 8656, 12123, 8899, 12114, 8909);
    context.bezierCurveTo(12104, 8920, 12031, 8926, 11793, 8936);
    context.bezierCurveTo(11624, 8943, 11436, 8951, 11375, 8954);
    context.bezierCurveTo(11315, 8957, 11247, 8960, 11224, 8960);
    context.lineTo(11184, 8960);
    context.lineTo(11011, 9199);
    context.bezierCurveTo(10874, 9390, 10834, 9440, 10812, 9444);
    context.bezierCurveTo(10444, 9520, 9921, 9598, 9529, 9636);
    context.bezierCurveTo(9376, 9650, 8651, 9664, 8560, 9654);
    context.closePath();
    context.moveTo(9400, 9005);
    context.bezierCurveTo(9712, 8977, 10141, 8922, 10396, 8879);
    context.lineTo(10457, 8868);
    context.lineTo(10464, 8747);
    context.bezierCurveTo(10467, 8680, 10475, 8533, 10480, 8420);
    context.bezierCurveTo(10522, 7533, 10550, 6930, 10555, 6850);
    context.bezierCurveTo(10566, 6641, 10572, 6520, 10600, 5910);
    context.bezierCurveTo(10616, 5561, 10632, 5242, 10635, 5201);
    context.lineTo(10641, 5128);
    context.lineTo(10608, 5132);
    context.bezierCurveTo(10590, 5135, 10465, 5153, 10330, 5173);
    context.bezierCurveTo(9834, 5246, 9567, 5265, 9000, 5265);
    context.bezierCurveTo(8531, 5265, 8420, 5259, 8170, 5219);
    context.bezierCurveTo(7826, 5165, 7525, 5039, 7283, 4849);
    context.bezierCurveTo(7248, 4822, 7216, 4800, 7210, 4800);
    context.bezierCurveTo(7204, 4800, 7200, 5276, 7198, 6193);
    context.bezierCurveTo(7194, 8230, 7194, 8197, 7208, 8265);
    context.bezierCurveTo(7268, 8542, 7379, 8689, 7622, 8815);
    context.bezierCurveTo(7819, 8917, 8102, 8988, 8440, 9020);
    context.bezierCurveTo(8584, 9033, 9197, 9024, 9400, 9005);
    context.closePath();
    context.moveTo(5780, 9001);
    context.bezierCurveTo(5927, 8983, 6115, 8942, 6227, 8905);
    context.bezierCurveTo(6566, 8792, 6763, 8607, 6852, 8318);
    context.lineTo(6875, 8245);
    context.lineTo(6878, 6527);
    context.bezierCurveTo(6880, 5142, 6878, 4810, 6868, 4817);
    context.bezierCurveTo(6861, 4821, 6816, 4851, 6768, 4883);
    context.bezierCurveTo(6493, 5066, 6132, 5180, 5660, 5236);
    context.bezierCurveTo(5475, 5257, 4983, 5265, 4745, 5251);
    context.bezierCurveTo(4407, 5230, 4001, 5188, 3626, 5135);
    context.bezierCurveTo(3532, 5121, 3455, 5112, 3453, 5114);
    context.bezierCurveTo(3451, 5116, 3456, 5263, 3464, 5441);
    context.bezierCurveTo(3473, 5619, 3486, 5923, 3495, 6115);
    context.bezierCurveTo(3503, 6308, 3512, 6512, 3515, 6570);
    context.bezierCurveTo(3528, 6838, 3531, 6917, 3545, 7235);
    context.bezierCurveTo(3553, 7422, 3569, 7771, 3580, 8010);
    context.bezierCurveTo(3591, 8249, 3602, 8526, 3606, 8625);
    context.bezierCurveTo(3610, 8724, 3616, 8814, 3621, 8826);
    context.bezierCurveTo(3627, 8842, 3642, 8849, 3697, 8858);
    context.bezierCurveTo(3734, 8865, 3830, 8881, 3910, 8895);
    context.bezierCurveTo(4184, 8942, 4509, 8982, 4775, 9000);
    context.bezierCurveTo(4863, 9006, 4955, 9012, 4980, 9014);
    context.bezierCurveTo(5077, 9022, 5690, 9011, 5780, 9001);
    context.closePath();
    context.moveTo(3195, 8333);
    context.bezierCurveTo(3192, 8284, 3181, 8061, 3170, 7835);
    context.bezierCurveTo(3159, 7610, 3143, 7295, 3135, 7135);
    context.bezierCurveTo(3117, 6791, 3086, 6155, 3065, 5730);
    context.bezierCurveTo(3049, 5408, 3044, 5312, 3034, 5135);
    context.lineTo(3027, 5026);
    context.lineTo(2877, 4800);
    context.bezierCurveTo(2795, 4676, 2723, 4571, 2718, 4565);
    context.bezierCurveTo(2708, 4556, 2712, 4731, 2725, 4925);
    context.bezierCurveTo(2728, 4964, 2737, 5121, 2745, 5275);
    context.bezierCurveTo(2753, 5429, 2769, 5722, 2780, 5925);
    context.bezierCurveTo(2791, 6129, 2809, 6466, 2820, 6675);
    context.bezierCurveTo(2831, 6884, 2847, 7181, 2855, 7335);
    context.bezierCurveTo(2863, 7489, 2872, 7651, 2875, 7695);
    context.bezierCurveTo(2877, 7739, 2883, 7827, 2886, 7890);
    context.lineTo(2893, 8005);
    context.lineTo(3044, 8212);
    context.bezierCurveTo(3127, 8327, 3196, 8420, 3198, 8420);
    context.bezierCurveTo(3200, 8420, 3199, 8381, 3195, 8333);
    context.closePath();
    context.moveTo(11039, 8197);
    context.lineTo(11188, 7989);
    context.lineTo(11194, 7897);
    context.bezierCurveTo(11197, 7846, 11209, 7645, 11220, 7450);
    context.bezierCurveTo(11231, 7255, 11249, 6938, 11260, 6745);
    context.bezierCurveTo(11319, 5717, 11343, 5308, 11355, 5080);
    context.bezierCurveTo(11358, 5028, 11365, 4918, 11370, 4835);
    context.bezierCurveTo(11375, 4753, 11380, 4661, 11380, 4631);
    context.lineTo(11380, 4577);
    context.lineTo(11216, 4814);
    context.lineTo(11052, 5050);
    context.lineTo(11046, 5138);
    context.bezierCurveTo(11042, 5186, 11028, 5441, 11015, 5705);
    context.bezierCurveTo(11001, 5969, 10976, 6437, 10960, 6745);
    context.bezierCurveTo(10943, 7053, 10921, 7476, 10910, 7685);
    context.bezierCurveTo(10889, 8090, 10884, 8180, 10874, 8330);
    context.bezierCurveTo(10870, 8397, 10871, 8422, 10879, 8415);
    context.bezierCurveTo(10885, 8409, 10956, 8311, 11039, 8197);
    context.closePath();
    context.moveTo(11744, 8252);
    context.bezierCurveTo(11747, 8215, 11752, 8147, 11755, 8100);
    context.bezierCurveTo(11758, 8053, 11776, 7772, 11795, 7475);
    context.bezierCurveTo(11830, 6941, 11842, 6750, 11920, 5550);
    context.bezierCurveTo(11942, 5212, 11967, 4829, 11975, 4700);
    context.bezierCurveTo(11983, 4571, 11992, 4431, 11995, 4390);
    context.bezierCurveTo(11998, 4349, 12009, 4176, 12020, 4005);
    context.bezierCurveTo(12031, 3835, 12042, 3662, 12045, 3621);
    context.lineTo(12051, 3548);
    context.lineTo(11918, 3555);
    context.bezierCurveTo(11845, 3559, 11783, 3564, 11781, 3566);
    context.bezierCurveTo(11779, 3568, 11795, 3632, 11818, 3708);
    context.lineTo(11860, 3845);
    context.lineTo(11850, 3990);
    context.bezierCurveTo(11845, 4070, 11800, 4783, 11750, 5575);
    context.bezierCurveTo(11700, 6367, 11642, 7300, 11620, 7649);
    context.bezierCurveTo(11598, 7998, 11580, 8293, 11580, 8304);
    context.bezierCurveTo(11580, 8324, 11585, 8325, 11659, 8322);
    context.lineTo(11738, 8319);
    context.lineTo(11744, 8252);
    context.closePath();
    context.moveTo(2485, 8183);
    context.bezierCurveTo(2482, 8140, 2468, 7912, 2455, 7675);
    context.bezierCurveTo(2429, 7241, 2405, 6826, 2395, 6670);
    context.bezierCurveTo(2388, 6558, 2341, 5768, 2280, 4720);
    context.bezierCurveTo(2264, 4442, 2248, 4188, 2246, 4155);
    context.bezierCurveTo(2243, 4122, 2238, 4029, 2234, 3949);
    context.lineTo(2227, 3803);
    context.lineTo(2270, 3676);
    context.bezierCurveTo(2293, 3606, 2310, 3547, 2307, 3544);
    context.bezierCurveTo(2302, 3539, 2047, 3520, 2042, 3524);
    context.bezierCurveTo(2041, 3526, 2067, 3965, 2100, 4501);
    context.bezierCurveTo(2133, 5037, 2176, 5734, 2195, 6050);
    context.bezierCurveTo(2214, 6366, 2232, 6659, 2235, 6700);
    context.bezierCurveTo(2238, 6741, 2258, 7068, 2280, 7425);
    context.bezierCurveTo(2302, 7783, 2322, 8117, 2326, 8168);
    context.lineTo(2332, 8260);
    context.lineTo(2412, 8260);
    context.lineTo(2491, 8260);
    context.lineTo(2485, 8183);
    context.closePath();
    context.moveTo(9200, 4670);
    context.bezierCurveTo(9649, 4649, 10030, 4608, 10562, 4524);
    context.lineTo(10789, 4488);
    context.lineTo(10909, 4307);
    context.bezierCurveTo(10975, 4207, 11028, 4125, 11027, 4124);
    context.bezierCurveTo(11026, 4122, 10759, 4139, 10435, 4160);
    context.bezierCurveTo(9827, 4200, 8871, 4262, 8205, 4305);
    context.bezierCurveTo(7996, 4318, 7801, 4331, 7772, 4334);
    context.bezierCurveTo(7721, 4338, 7718, 4337, 7662, 4289);
    context.bezierCurveTo(7631, 4262, 7567, 4220, 7520, 4196);
    context.bezierCurveTo(7436, 4152, 7302, 4105, 7292, 4115);
    context.bezierCurveTo(7289, 4118, 7308, 4152, 7334, 4190);
    context.bezierCurveTo(7583, 4553, 8214, 4716, 9200, 4670);
    context.closePath();
    context.moveTo(5480, 4660);
    context.bezierCurveTo(6053, 4627, 6394, 4525, 6614, 4320);
    context.bezierCurveTo(6670, 4269, 6766, 4137, 6752, 4132);
    context.bezierCurveTo(6736, 4127, 6588, 4188, 6535, 4221);
    context.bezierCurveTo(6507, 4238, 6466, 4270, 6442, 4292);
    context.lineTo(6399, 4331);
    context.lineTo(6332, 4325);
    context.bezierCurveTo(6295, 4322, 5941, 4297, 5545, 4270);
    context.bezierCurveTo(4701, 4212, 4420, 4193, 3665, 4140);
    context.bezierCurveTo(3357, 4119, 3104, 4103, 3102, 4105);
    context.bezierCurveTo(3098, 4108, 3315, 4447, 3334, 4468);
    context.bezierCurveTo(3349, 4483, 3482, 4507, 3850, 4560);
    context.bezierCurveTo(4478, 4650, 5046, 4685, 5480, 4660);
    context.closePath();
    context.fill();
    context.stroke();
    context.restore();
    context.restore();
    context.restore();
  }
}

class PuzzlePieceIcon extends Drawable {
  x: number;
  y: number;

  public draw(context: any) {
    context.save();
    context.translate(this.x, this.y);
    context.beginPath();
    context.moveTo(0, 0);
    context.lineTo(25, 0);
    context.lineTo(25, 25);
    context.lineTo(0, 25);
    context.closePath();
    context.clip();
    context.translate(0, 0.000034233561899910114);
    context.scale(0.0684671237988299, 0.0684671237988299);
    context.translate(0, 0);
    context.strokeStyle = 'rgba(0,0,0,0)';
    context.lineCap = 'butt';
    context.lineJoin = 'miter';
    context.miterLimit = 4;
    context.save();
    context.fillStyle = "#030303";
    context.beginPath();
    context.moveTo(228.246, 292.11);
    context.lineTo(129.05, 292.11);
    context.lineTo(139.84, 267.50100000000003);
    context.bezierCurveTo(141.399, 263.95500000000004, 142.179, 260.192, 142.179, 256.293);
    context.bezierCurveTo(142.179, 240.826, 129.594, 228.24, 114.126, 228.24);
    context.bezierCurveTo(98.656, 228.24, 86.07400000000001, 240.82600000000002, 86.07400000000001, 256.293);
    context.bezierCurveTo(86.07400000000001, 260.192, 86.85700000000001, 263.967, 88.40400000000001, 267.50100000000003);
    context.lineTo(99.17600000000001, 292.105);
    context.lineTo(0.005, 292.105);
    context.lineTo(0.005, 63.868);
    context.lineTo(90.704, 63.868);
    context.bezierCurveTo(90.878, 63.611000000000004, 90.978, 63.330000000000005, 90.978, 63.108000000000004);
    context.bezierCurveTo(90.978, 63.074000000000005, 90.978, 63.036, 90.972, 63.002);
    context.bezierCurveTo(90.118, 62.276, 89.443, 61.695, 88.54199999999999, 60.812000000000005);
    context.bezierCurveTo(81.916, 53.99, 78.319, 45.15, 78.319, 35.81);
    context.bezierCurveTo(78.319, 16.065, 94.387, 0, 114.131, 0);
    context.bezierCurveTo(133.875, 0, 149.941, 16.065, 149.941, 35.81);
    context.bezierCurveTo(149.941, 45.162000000000006, 146.347, 54.001000000000005, 139.817, 60.706);
    context.lineTo(137.57500000000002, 62.693000000000005);
    context.bezierCurveTo(137.49200000000002, 62.885000000000005, 137.46400000000003, 63.025000000000006, 137.46400000000003, 63.096000000000004);
    context.bezierCurveTo(137.46400000000003, 63.353, 137.56400000000002, 63.617000000000004, 137.72700000000003, 63.857000000000006);
    context.lineTo(228.24600000000004, 63.857000000000006);
    context.lineTo(228.24600000000004, 154.479);
    context.bezierCurveTo(228.49800000000005, 154.616, 228.81800000000004, 154.72400000000002, 229.13300000000004, 154.72400000000002);
    context.bezierCurveTo(229.67600000000004, 154.14700000000002, 230.34500000000003, 153.358, 231.31100000000003, 152.38600000000002);
    context.bezierCurveTo(238.13300000000004, 145.76700000000002, 246.97900000000004, 142.17000000000002, 256.29900000000003, 142.17000000000002);
    context.bezierCurveTo(276.03700000000003, 142.17000000000002, 292.10600000000005, 158.241, 292.10600000000005, 177.98000000000002);
    context.bezierCurveTo(292.10600000000005, 197.73000000000002, 276.03800000000006, 213.79200000000003, 256.29900000000003, 213.79200000000003);
    context.bezierCurveTo(246.96700000000004, 213.79200000000003, 238.12100000000004, 210.19500000000002, 231.39100000000002, 203.65400000000002);
    context.lineTo(229.413, 201.49200000000002);
    context.bezierCurveTo(229.047, 201.43500000000003, 228.572, 201.53300000000001, 228.246, 201.698);
    context.lineTo(228.246, 292.11);
    context.closePath();
    context.moveTo(146.973, 280.4);
    context.lineTo(216.53500000000002, 280.4);
    context.lineTo(216.53500000000002, 200.22099999999997);
    context.bezierCurveTo(216.53500000000002, 198.82599999999996, 216.90600000000003, 197.44899999999998, 217.60900000000004, 196.265);
    context.bezierCurveTo(221.14300000000003, 190.16899999999998, 230.14300000000003, 187.88199999999998, 236.23900000000003, 191.862);
    context.lineTo(237.39300000000003, 192.857);
    context.lineTo(239.56100000000003, 195.27);
    context.bezierCurveTo(244.08300000000003, 199.662, 250.03100000000003, 202.086, 256.297, 202.086);
    context.bezierCurveTo(269.586, 202.086, 280.39300000000003, 191.27300000000002, 280.39300000000003, 177.99);
    context.bezierCurveTo(280.39300000000003, 164.70100000000002, 269.581, 153.883, 256.297, 153.883);
    context.bezierCurveTo(250.03500000000002, 153.883, 244.08300000000003, 156.30700000000002, 239.54900000000003, 160.71);
    context.bezierCurveTo(239.02800000000005, 161.23600000000002, 238.62200000000004, 161.739, 238.21700000000004, 162.23600000000002);
    context.bezierCurveTo(237.47300000000004, 163.169, 236.47900000000004, 164.11700000000002, 235.65500000000003, 164.67200000000002);
    context.bezierCurveTo(228.41700000000003, 168.70300000000003, 221.00600000000003, 165.747, 217.59800000000004, 159.88700000000003);
    context.bezierCurveTo(216.89500000000004, 158.66300000000004, 216.53500000000005, 157.32500000000002, 216.53500000000005, 155.95200000000003);
    context.lineTo(216.53500000000005, 75.578);
    context.lineTo(136.36200000000005, 75.578);
    context.bezierCurveTo(134.99300000000005, 75.578, 133.64000000000004, 75.215, 132.45700000000005, 74.537);
    context.bezierCurveTo(128.32300000000004, 72.147, 125.75800000000005, 67.76700000000001, 125.75800000000005, 63.107000000000006);
    context.bezierCurveTo(125.75800000000005, 60.614000000000004, 126.53600000000006, 58.11200000000001, 128.01400000000004, 55.86500000000001);
    context.lineTo(129.62900000000005, 54.07800000000001);
    context.lineTo(131.22700000000006, 52.73700000000001);
    context.bezierCurveTo(135.87600000000006, 47.86000000000001, 138.22300000000007, 42.00500000000001, 138.22300000000007, 35.80900000000001);
    context.bezierCurveTo(138.22300000000007, 22.51700000000001, 127.41600000000007, 11.710000000000011, 114.12400000000006, 11.710000000000011);
    context.bezierCurveTo(100.83200000000006, 11.710000000000011, 90.02300000000007, 22.51700000000001, 90.02300000000007, 35.80900000000001);
    context.bezierCurveTo(90.02300000000007, 42.08100000000001, 92.44700000000007, 48.02300000000001, 96.83900000000007, 52.551000000000016);
    context.bezierCurveTo(97.36500000000006, 53.06600000000002, 97.81700000000006, 53.44000000000002, 98.26300000000007, 53.792000000000016);
    context.bezierCurveTo(99.25800000000008, 54.59200000000001, 100.24100000000007, 55.625000000000014, 100.79600000000008, 56.448000000000015);
    context.bezierCurveTo(102.13700000000007, 58.856000000000016, 102.68300000000008, 60.98000000000002, 102.68300000000008, 63.10100000000001);
    context.bezierCurveTo(102.68300000000008, 67.74400000000001, 100.13600000000008, 72.11300000000001, 96.03000000000007, 74.49900000000001);
    context.bezierCurveTo(94.82400000000007, 75.203, 93.46000000000008, 75.57100000000001, 92.07900000000008, 75.57100000000001);
    context.lineTo(11.716, 75.57100000000001);
    context.lineTo(11.716, 280.387);
    context.lineTo(81.27, 280.387);
    context.lineTo(77.682, 272.188);
    context.bezierCurveTo(75.486, 267.162, 74.368, 261.815, 74.368, 256.292);
    context.bezierCurveTo(74.368, 234.36899999999997, 92.202, 216.52899999999997, 114.131, 216.52899999999997);
    context.bezierCurveTo(136.057, 216.52899999999997, 153.894, 234.36899999999997, 153.894, 256.292);
    context.bezierCurveTo(153.894, 261.82099999999997, 152.78, 267.16799999999995, 150.572, 272.19899999999995);
    context.lineTo(146.973, 280.4);
    context.closePath();
    context.fill();
    context.stroke();
    context.restore();
    context.restore();
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
    circle.lineWidth = this.settingsService.settings.ui.characterNode.borderWidth * this.settingsService.settings.ui.newRelationship.nodeHighlightFactor;
    this.foregroundDrawables.push(circle);
  }

  drawRectangularNodeHighlight(x: number, y: number, width: number, height: number) {
    let rectangle = new Rectangle();
    rectangle.x = x;
    rectangle.y = y;
    rectangle.width = width;
    rectangle.height = height;
    rectangle.style = this.settingsService.settings.ui.newRelationship.arrow.style;
    rectangle.lineWidth = this.settingsService.settings.ui.storylineNode.borderWidth * this.settingsService.settings.ui.newRelationship.nodeHighlightFactor;
    this.foregroundDrawables.push(rectangle);
  }

  drawPuzzlePieceIcon(x: number, y: number) {
    let puzzlePieceIcon = new PuzzlePieceIcon();
    puzzlePieceIcon.x = x;
    puzzlePieceIcon.y = y;
    this.foregroundDrawables.push(puzzlePieceIcon);
  }

  drawBookIcon(x: number, y: number) {
    let bookIcon = new BookIcon();
    bookIcon.x = x;
    bookIcon.y = y;
    this.foregroundDrawables.push(bookIcon);
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
