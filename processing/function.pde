// テクスチャ用の画像を左右反転させたい関数
// Function to flip horizontal the image for the texture.
PImage horizontalFlip(PImage img){
  PImage tmp = createImage(img.width, img.height, RGB);
  for(int i = 0; i < img.height; i++){
    for(int j = img.width * i, k = (img.width * i) + (img.width - 1); j <= (img.width * i) + (img.width - 1); j++, k--){
      tmp.pixels[k] = img.pixels[j];
    }
  }
  return tmp;
}

// PGraphics用flip関数
// Function to flip horizontal the PGraphics
PGraphics horizontalFlip(PGraphics img){
  //tmpの用意
  PGraphics tmp = createGraphics(img.width, img.height);
  tmp.beginDraw();
  tmp.endDraw();

  //移植処理
  for(int i = 0; i < img.height; i++){
    for(int j = img.width * i, k = (img.width * i) + (img.width - 1); j <= (img.width * i) + (img.width - 1); j++, k--){
      tmp.pixels[k] = img.pixels[j];
    }
  }
  return tmp;
}

// テクスチャ用の画像を上下反転させたい関数
// Function to flip vertical the image for the texture.
PImage verticalFlip(PImage img){
  PImage tmp = createImage(img.width, img.height, RGB);
  for(int i = 0; i < img.height; i++){
    for(int j = img.width * i, k = img.width * (img.height - i - 1); j <= (img.width * i) + (img.width - 1); j++, k++){
      tmp.pixels[k] = img.pixels[j];
    }
  }
  return tmp;
}

// PGraphics用flip関数
// Function to flip vertical the PGraphics
PGraphics verticalFlip(PGraphics img){
  //tmpの用意
  PGraphics tmp = createGraphics(img.width, img.height);
  tmp.beginDraw();
  tmp.endDraw();
  
  for(int i = 0; i < img.height; i++){
    for(int j = img.width * i, k = img.width * (img.height - i - 1); j <= (img.width * i) + (img.width - 1); j++, k++){
      tmp.pixels[k] = img.pixels[j];
    }
  }
  return tmp;
}

// 引数にある文字列を改行コードでパースする関数
ArrayList<String> parser(String str){
    int before = 0;
    ArrayList<String> tmp = new ArrayList<String>();
    for(int i = 0; i < str.length() - 1; i++){
        if("\n".equals(str.substring(i,i+1))){
            tmp.add(str.substring(before, i));
            before = i + 2;
        }else if(i == str.length() - 2){
            tmp.add(str.substring(before, i + 2));
        }
    }
    return tmp;
}