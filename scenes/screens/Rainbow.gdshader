shader_type canvas_item;

uniform float time = 0;
uniform sampler2D gradient;
uniform float num_gradients : hint_range(2.0, 10.0, 1.0) = 7;
uniform float angle = 0;
uniform vec2 offset = vec2(0);
uniform float aspect_ratio = 1.777778;

void fragment() {
	float p = (UV.y + offset.x) * sin(angle) 
		- (UV.x + offset.x) * aspect_ratio * cos(angle);
	float raw_index = floor(p * num_gradients);
	float index = abs(mod(raw_index, num_gradients * 2.0 - 2.0) - num_gradients + 1.0); // gradients are mirrored at boundary
	float value = (index + 0.5) / float(num_gradients);
	vec4 rgba = texture(gradient, vec2(value));
	
	float q = UV.y * cos(angle) 
		+ UV.x * aspect_ratio * sin(angle);
	rgba.a = step(q + sin(time) + offset.y, time);
	COLOR = rgba;
}