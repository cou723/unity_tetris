# tetris_tutorial dev log
https://masavlog.com/programming/tetris/unity-tetris-1/
https://masavlog.com/programming/tetris/unity-tetris-2/
ここを参考に作ってみる

https://craft-gogo.com/unity-puzzle-game2/
変更
ここを参考に作ってみる
後者の方が信憑性が高い気がする

## Spriteとは
> Unityが表示されるとAssetsフォルダを右クリックして、Create→Sprites→Squareの順で選択します。
https://xr-hub.com/archives/9524
2Dグラフィックオブジェクト
2Dゲームで画像データを表示するときに使う
画像をAssetsの中にD&Dするだけでも行ける
Spriteの拡大縮小でSprite Editorを使うとよき
複数のSpriteを一つのSpriteにまとめることもできる

## Prefabとは
> TminoのPrefab化

https://www.google.com/search?q=unity+prefab+%E3%81%A8%E3%81%AF&oq=unity+prefab+%E3%81%A8%E3%81%AF&aqs=chrome..69i57.2312j0j7&sourceid=chrome&ie=UTF-8

> コンポネントやマテリアルを紐づけ(アタッチ)したゲームオブジェクトをアセットとして扱い、記録することでコピーを複製できるようにしたもの

https://miyagame.net/prefab/
Prefab = classのようなもの
Prefabからインスタンスを作る

## Order in Layer
Layerの描画の優先度

## Cameraのサイズ
Sizeから拡大率を変えられる

## スクリプトのアタッチ
コンポーネントを選択した状態で右側のAddComponentをクリック、New Scriptを選択

## Coding
### transform
transform: GameObjectにアタッチされる奴,positionとかある
Vector3()は+=で加算できる

### Instantiate
Prefabからインスタンスを位置、回転を決めた状態で生成できる。

### 四角い配列
配列の配列と違い、要素数が同じものの配列の集合のみしか作れない
```cs
型名[,] 変数名; // 2次元配列
型名[,,] 変数名; // 3次元配列
```
|     | 回転  | 位置x | 位置y |
| --- | :---: | :---: | :---: |
| T:  |   o   |   x   |   o   |
| J:  |   o   |   x   |   o   |
| L:  |   o   |   x   |   o   |
| S:  |   o   |   x   |   x   |
| Z:  |   o   |   x   |   x   |
| I:  |   o   |   o   |   x   |
| O:  |   o   |   o   |   x   |