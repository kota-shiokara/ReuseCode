class Plot {
  private PGraphics pg; // plot用PGrafhics

  // グラフのmargin
  private float plotMarginWidth;
  private float plotMarginHeight;

  // plotに使うデータ群
  private float[] xArray;
  private float[] yArray;
  private boolean setArray = false;
  private FloatList xList = new FloatList();
  private FloatList yList = new FloatList();
  private boolean setList = false;
  // データ群の大きさ
  private float parmNum;

  Plot(PApplet p) {
    setGraphics(p);
  }

  Plot(PApplet p, float[] _xArray, float[] _yArray) {
    setGraphics(p);
    setArray(_xArray, _yArray);
  }

  Plot(PApplet p, FloatList _xList, FloatList _yList) {
    setGraphics(p);
    setList(_xList, _yList);
  }

  void setGraphics(PApplet p){
    pg = createGraphics(p.width, p.height);
    plotMarginWidth = p.width * 0.02;
    plotMarginHeight = p.height * 0.02;
  }

  void setArray(float[] _xArray, float[] _yArray) {
    xArray = _xArray;
    yArray = _yArray;
    parmNum = xArray.length;
    setArray = true;

    if (parmNum != yArray.length) {
      println("The size of array is different.");
      exit();
    }
  }

  void setList(FloatList _xList, FloatList _yList) {
    xList = _xList;
    yList = _yList;
    parmNum = xList.size();
    setList = true;

    if (parmNum != yList.size()) {
      println("The size of list is different.");
      exit();
    }
  }

  PGraphics show() {
    pg.beginDraw();

    pg.endDraw();
    pg = verticalFlip(pg);
    return pg;
  }

  PGraphics verticalFlip(PGraphics img) {
    //tmpの用意
    PGraphics tmp = createGraphics(img.width, img.height);
    tmp.beginDraw();
    tmp.endDraw();

    for (int i = 0; i < img.height; i++) {
      for (int j = img.width * i, k = img.width * (img.height - i - 1); j <= (img.width * i) + (img.width - 1); j++, k++) {
        tmp.pixels[k] = img.pixels[j];
      }
    }
    return tmp;
  }
}
