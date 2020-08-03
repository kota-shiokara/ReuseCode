// テクスチャ用の画像を左右反転させたい関数
// Function to flip horizontal the image for the texture.
PImage flip(PImage img){
  PImage tmp = createImage(img.width, img.height, RGB);
  for(int i = 0; i < img.height; i++){
    for(int j = img.width * i, k = (img.width * i) + (img.width - 1); j <= (img.width * i) + (img.width - 1); j++, k--){
      tmp.pixels[k] = img.pixels[j];
    }
  }
  return tmp;
}