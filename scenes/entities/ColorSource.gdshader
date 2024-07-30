shader_type canvas_item;

uniform int num_horn : hint_range(0, 40, 1) = 3;
uniform float horn_length = 0.1;
uniform vec4 color : source_color;

void fragment() {
	float length_to_center = distance(UV, vec2(0.5));
	float angle_from_center = atan(UV.y-0.5, UV.x-0.5);
	float offset = abs(mod(angle_from_center*float(num_horn)/PI, 2.0)-1.0) * horn_length;
	float cutoff = 0.5 - horn_length + offset;
	COLOR = vec4(color.rgb, 1.0 - step(cutoff, length_to_center));
}
