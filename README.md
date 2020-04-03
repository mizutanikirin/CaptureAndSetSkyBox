# CaptureAndSetSkyBox
CaptureAndSetSkyBoxは360°キャプチャした画像をSkyBox/Panoramicのマテリアルに割当を行うAssetです。
![0](https://user-images.githubusercontent.com/4795806/78316122-d4de3580-7599-11ea-9dda-0709e59008d3.png)  
※360° キャプチャは[Unity360ScreenshotCapture](https://github.com/yasirkula/Unity360ScreenshotCapture)を使用しています。

# 使い方
### 1. インポート
1. CaptureAndSetSkyBox
  [CaptureAndSetSkyBox.unitypackage](https://github.com/mizutanikirin/CaptureAndSetSkyBox/releases/tag/ver.1.0.0)をインポートします。
2. Unity360ScreenshotCapture
  360°キャプチャはyasirkulaさんの[Unity360ScreenshotCapture](https://github.com/yasirkula/Unity360ScreenshotCapture)を使用しています。こちらのAssetをインポートします。

### 2. カメラの設定
![3](https://user-images.githubusercontent.com/4795806/78238159-39a47c00-7517-11ea-97f8-cd1305e4bfed.png)
1. カメラに`SkyBox`をAdd Componentする。
2. `Inspector > customSkybox`にskyboxのマテリアルを割り当てる。(※マテリアルはSkybox/Panoramicになっている必要あり)

### 3. CaptureAndSetSkyBoxの設定
![1](https://user-images.githubusercontent.com/4795806/78238697-d6671980-7517-11ea-9b6f-f9a9648dc1ab.png)
1. `CaptureAndSetSkyBox/Prefabs/CaptureAndSetSkyBox`をHierarchyにドロップする。
2. 各変数の設定をする
```  
  customSkyBox:
    2のカメラを指定する
  
  skyboxBaseTexture:
    元となるSkyBox用のTextureを指定する。
  
  imageWidth:
    キャプチャする画像サイズを指定する。
    
```

### 4. skyboxBaseTextureの設定
![2](https://user-images.githubusercontent.com/4795806/78236273-b6822680-7514-11ea-86e8-d6173fcda7c3.png)
- `Advanced > Generate Mip Maps`はoffにしておきます。(※補足参照)
- `Max Size`は必要な大きさに合わせて変更してください。

<b>[補足]</b>  
ここがOnのままだと以下のようにつなぎ目に線が表示されてしまいます。
![4](https://user-images.githubusercontent.com/4795806/78316550-e96efd80-759a-11ea-9e97-b3a3ab370ca5.png)