shader_type canvas_item;

uniform float time = 0;
uniform sampler2D gradient;

void fragment() {
	COLOR = texture(gradient, vec2(UV.y));
}