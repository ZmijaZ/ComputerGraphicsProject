#version 330 core
out vec4 FragColor;

in vec2 TexCoords;

uniform sampler2D hdrBuffer;
uniform bool hdr;
uniform float exposure;

uniform sampler2D screenTexture;

uniform int colorScheme;

void main()
{

 const float gamma = 2.2;
    vec3 hdrColor = texture(hdrBuffer, TexCoords).rgb;
    if(hdr)
    {
        // exposure
        vec3 result = vec3(1.0) - exp(-hdrColor * exposure);
        // also gamma correct while we're at it
        result = pow(result, vec3(1.0 / gamma));
        FragColor = vec4(result, 1.0);
    }
    else
    {
        if(colorScheme == 0){
            vec3 result = pow(hdrColor, vec3(1.0 / gamma));
            FragColor = vec4(result, 1.0);
        }else if (colorScheme == 1){
            FragColor = vec4(vec3(1.0 - texture(screenTexture, TexCoords)), 1.0);
        }
        else{
            FragColor = texture(screenTexture, TexCoords);
            float average = (FragColor.r + FragColor.g + FragColor.b)/3.0;
            FragColor = vec4(average, average, average, 1.0);
        }

    }


// if (colorScheme == 0){
//     vec3 col = texture(screenTexture, TexCoords).rgb;
//     FragColor = vec4(col, 1.0);
//     }
// else if (colorScheme == 1) {
//     FragColor = vec4(vec3(1.0 - texture(screenTexture, TexCoords)), 1.0);
//     }
// else{
//     FragColor = texture(screenTexture, TexCoords);
//     float average = (FragColor.r + FragColor.g + FragColor.b)/3.0;
//     FragColor = vec4(average, average, average, 1.0);
// }

}