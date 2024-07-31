shader_type canvas_item;

uniform vec4 color : source_color = vec4(1.0);
uniform int num_horn : hint_range(0, 40, 1) = 5;
uniform float horn_length = 0.2;
uniform float horn_start : hint_range(0.0, 0.5, 0.01) = 0.3;
uniform float inner_radius : hint_range(0.0, 0.5, 0.01) = 0.2;
uniform bool rotate = false;

void fragment() {
	float length_to_center = distance(UV, vec2(0.5));
	float angle_from_center = atan(UV.y-0.5, UV.x-0.5)
		+ TIME * 1.0 * float(rotate);
	float scaled_angle = angle_from_center * float(num_horn) / PI;
	float scaled_horn_length = abs(mod(scaled_angle, 2.0)-1.0) * horn_length;
	float horn_tip = 0.5 - horn_length + scaled_horn_length;

	float inner_alpha = 1.0 - smoothstep(inner_radius - 0.02, inner_radius + 0.02, length_to_center);
	float horn_alpha = smoothstep(horn_start - 0.02, horn_start + 0.02, length_to_center)
		* smoothstep(length_to_center - 0.02, length_to_center + 0.02, horn_tip);
	float alpha = inner_alpha + horn_alpha;

	COLOR = vec4(color.rgb, alpha);
}
