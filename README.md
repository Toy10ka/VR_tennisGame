# 🎾 VR Zero Gravity Tennis (仮)

無重力空間のコートで、一定速度で滑るボールをラケットで弾き、Goal に当ててクリアを目指す VR 向けのテニス風ミニゲームです。  
Out に触れるとボールは初期位置へリセットされ、演出が2秒間表示されます。まだ制作途中です。

---

## 🎮 遊び方 / How to Play

- VR コントローラーでラケット（`tennis_bat`）を掴んでボールを弾き返します。
- ボールは常に一定速度で移動し、衝突で方向が変わります。
- Goal に当てるとゴール演出。Out に触れると位置・回転・速度がリセットされアウト演出が 2 秒表示されます。
- テレポート移動（XRI の標準挙動）に対応  
  ※ 操作方法は XRI Starter Assets のデフォルトを想定。環境により当てはまらない場合があります。

---

## 📂 プロジェクト構成 / Project Structure

Assets/
├─ Scenes/ … メインシーン（例: ZeroGravityTennis.unity）
├─ Scripts/ … ゲームロジック（ZEROGRAVITYTENNIS など）
├─ XR/ … XR Plugin Management 設定
├─ XRI/ … XRI 設定
├─ Samples/ … XR Interaction Toolkit 3.0.8 / Starter Assets / XRI サンプル（必要に応じて）
├─ Art/ … モデルや素材（Sci-Fi Styled Modular Pack / FreeSportsKit_SA などのサードパーティ資産）
ProjectSettings/
Packages/


> **注**: リポジトリには `.meta` のみが含まれる場合があります。実体アセットは含まれていません。必要に応じて別途 Import してください。

---

## 📦 依存ソフト / Requirements

- Unity **6.0**（例: `6000.0.5x` 以降）
- XR Interaction Toolkit **3.0.8+**（Starter Assets 推奨）
- XR Plugin Management（OpenXR を有効）
- Input System（新インプットシステム）
- XR Device Simulator（PC デバッグ用、XRI Samples から追加）
- Sci-Fi Styled Modular Pack（ステージ用）
- FreeSportsKit_SA（ラケット・ボール等）

---

## 🛠 セットアップ / Setup

1. このリポジトリをクローンまたはダウンロード
2. Unity Hub で Unity 6.0 以上のバージョンで開く
3. `Package Manager` で下記を確認・インポート
    - XR Interaction Toolkit 3.0.8（Starter Assets / Device Simulator も必要なら Import）
    - XR Plugin Management を有効化し、OpenXR を Standalone / Android 環境で有効
4. 必要に応じて `.meta` のみに含まれるサードパーティアセットを同バージョンの実体アセットで復元

---

## 📌 今後の TODO / Ideas

- 難易度選択に応じた制限時間の調整
- フグのスポーン位置のランダム化
- モバイル操作対応（ジャイロ + タッチ UI）
- ギミック追加（例: 毒を持ったフグ）
- サウンド実装
