# 🎾 VR Zero Gravity Tennis 

無重力空間のコートで、ボールをラケットで弾き、Goal に当ててクリアを目指す VR ゲームです。  
Out に触れるとボールは初期位置へリセットされ、演出が2秒間表示されます。

---

## 🎮 遊び方 / How to Play

- VR コントローラーでラケット（`tennis_bat`）を掴んでボールを弾き返します。
- ボールは常に一定速度で移動し、衝突で方向が変わります。
- Goal に当てるとゴール演出。Out に触れると位置・回転・速度がリセットされアウト演出が 2 秒表示されます。

---

## 📂 プロジェクト構成 / Project Structure

```text
Assets/
├─ Scenes/ … メインシーン（例: ZeroGravityTennis.unity）
├─ Scripts/ … ゲームロジック（ZEROGRAVITYTENNIS など）
├─ XR/ … XR Plugin Management 設定
├─ XRI/ … XRI 設定
├─ Samples/ … XR Interaction Toolkit / Starter Assets /
├─ Art/ … モデルや素材
├─ ProjectSettings/
├─ Packages/
└─ README.md … このファイル
```
---

## 📦 依存ソフト / Requirements

- Unity 6.0 (6000.0.50f1)
- XR Interaction Toolkit 3.0.8+（Starter Assets 推奨）
- XR Plugin Management（OpenXR を有効）

---

## 🛠 セットアップ / Setup

1. このリポジトリをクローンまたはダウンロード
2. Unity Hub で Unity 6.0 以上のバージョンで開く
3. `Package Manager` で下記を確認・インポート
    - XR Interaction Toolkit 3.0.8（Starter Assets / Device Simulator も必要なら Import）
    - XR Plugin Management を有効化し、OpenXR を Standalone / Android 環境で有効
4. 必要に応じて `.meta` のみに含まれるサードパーティアセットを同バージョンの実体アセットで復元

---


