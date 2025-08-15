# 🎾 VR Zero Gravity Tennis 

無重力空間で繰り広げられる、新感覚のVRテニスゲームです。
動く障害物を避けながらボールを打ち返し、Goalに当ててハイスコアを目指しましょう。

![](Demo/image.png) 
---
## 🌟 主な特徴 / Features

* **無重力でのラリー体験:** 地上のテニスとは一味違う、予測不能なボールの動きが楽しめます。
* **スキルが試される動く障害物:** ステージ内を上下左右に動く障害物が、単調なラリーを戦略的なゲームへと進化させます。
* **段階的な難易度上昇:** `Goal`を決めるたびにボールが加速 (`SpeedIncrement = 0.5f`)。あなたの限界はどこまで？
* **リアルなハプティクスフィードバック:** ボールを打ち返すと、VRコントローラーが振動。爽快な打感をその手に伝えます。
* **ベストスコアの自動保存:** 叩き出したハイスコアは自動で記録されます。自己ベスト更新を目指して、何度でも挑戦できます！
  
---

## 🎮 遊び方 / How to Play

### 操作方法
- VRコントローラーでラケット (`tennis_bat`) を掴み、ボールを打ち返します。

### ルール
1.  **Goal (奥の壁):**
    - ボールを当てるとスコアが **+1** されます。
    - スコア獲得時にエフェクトと効果音が再生され、ボールの速度が上昇します。
2.  **Out (手前の壁):**
    - ボールが触れると **ゲームオーバー** となります。
    - BGMが停止し、ゲームオーバー演出と効果音が再生された後、ボールが初期位置にリセットされます。

---

## 🛠 セットアップ / Setup

1. このリポジトリをクローンまたはダウンロード
2. Unity Hub で Unity 6.0 以上のバージョンで開く
3. `Package Manager` で下記を確認・インポート
    - XR Interaction Toolkit 3.0.8（Starter Assets / Device Simulator も必要なら Import）
    - XR Plugin Management を有効化し、OpenXR を Standalone / Android 環境で有効
4. 必要に応じて `.meta` のみに含まれるサードパーティアセットを同バージョンの実体アセットで復元

---
## 📦 技術仕様 / Requirements

- Unity 6.0 (6000.0.50f1)
- XR Interaction Toolkit 3.0.8+（Starter Assets 推奨）
- XR Plugin Management（OpenXR を有効）

---
## 📂 プロジェクト構成 / Project Structure

```text
Assets/
├─ Scenes/ … メインシーン
├─ Scripts/ … ゲームロジック
├─ XR/ … XR Plugin Management 設定
├─ XRI/ … XRI 設定
├─ Samples/ … XR Interaction Toolkit / Starter Assets /
├─ Art/ … モデルや素材
├─ ProjectSettings/
├─ Packages/
└─ README.md … このファイル
```
---


