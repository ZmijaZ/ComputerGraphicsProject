#version 330 core
out vec4 FragColor;

in vec2 TexCoords;

uniform sampler2D screenTexture;

uniform int colorScheme;

void main()
{
if (colorScheme == 0){
    vec3 col = texture(screenTexture, TexCoords).rgb;
    FragColor = vec4(col, 1.0);
    }
else if (colorScheme == 1) {
    FragColor = vec4(vec3(1.0 - texture(screenTexture, TexCoords)), 1.0);
    }
else{
    FragColor = texture(screenTexture, TexCoords);
    float average = (FragColor.r + FragColor.g + FragColor.b)/3.0;
    FragColor = vec4(average, average, average, 1.0);
}

}