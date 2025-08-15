🎾 ZeroGravityTennis (VR)

無重力空間のコートで、一定速度で滑るボールをラケットで弾き、Goal に当ててクリアを目指す VR 向けのテニス風ミニゲームです。
Out に触れるとボールは初期位置へリセットされ、演出が2秒間表示されます。まだ制作途中です。

🎮 遊び方 / How to Play

VR コントローラでラケット（tennis_bat）を掴んでボールを弾き返します。

ボールは常に一定速度で移動し、衝突で方向だけ変わります。

Goal に当てるとゴール演出、Out に触れると位置・回転・速度がリセットされアウト演出が2秒表示されます。

テレポート移動（XRI の標準挙動）に対応。
※ 操作法は XRI Starter Assets のデフォルトを想定。環境により割り当ては異なります。

🧱 プロジェクト構成 / Project Structure
Assets/
├─ Scenes/              … メインシーン（例：ZeroGravityTennis.unity）
├─ Scripts/             … ゲームロジック（ZEROGRAVITYTENNIS.cs など）
├─ XR/                  … XR Plugin Management 設定
├─ XRI/                 … XRI 設定
├─ Samples/
│   └─ XR Interaction Toolkit/3.0.8/Starter … XRI サンプル（必要に応じて）
└─ (※ Sci-Fi Styled Modular Pack / FreeSportsKit_SA 等の
     サードパーティ資産は **含めていません**。必要なら各自 Import)
ProjectSettings/
Packages/

🧩 依存ソフト / Requirements

Unity 6.0（例：6000.0.5x 以降）

XR Interaction Toolkit 3.0.8+（Starter Assets 推奨）

XR Plugin Management（OpenXR を有効）

Input System（新インプットシステムを使用）

（PC でデバッグする場合）XR Device Simulator（XRI の Samples から追加）

このリポジトリは公開のため、サードパーティの実体アセットは含めていません（.meta のみ含まれる場合があります）。
必要に応じて以下を各自インポートしてください（任意・例）：

Sci-Fi Styled Modular Pack（ステージ用）

FreeSportsKit_SA（ラケット・ボール等）
同じバージョンを同名フォルダに Import すれば、多くは GUID が一致して参照が復元されます。

🛠 セットアップ / Setup

このリポジトリをクローンまたはダウンロード

Unity Hub で本プロジェクトを Unity 6.0 で開く

Package Manager で下記を確認/導入

XR Interaction Toolkit 3.0.8（Starter Assets / Device Simulator も必要なら Import）

XR Plugin Management を有効化し、OpenXR を Standalone/Android 対応環境で有効

Input System を有効（必要なら自動リスタート）

（任意）不足している外部アセットをインポート

Scenes のメインシーンを開き、Play で動作確認

🧪 操作（デフォルト想定）

掴む / つかみ離し：コントローラのトリガー（XRI の Select）

テレポート：サムスティック + ポインタ（XRI 標準）

PC デバッグ：XR Device Simulator をシーンに置けば、キーボード/マウスで視点・手の動作を模擬できます。

※ 実際の割り当ては Assets/Samples/XR Interaction Toolkit/…/Input の Input Actions に依存します。

🧠 実装メモ（現状）

ZEROGRAVITYTENNIS.cs

Rigidbody.linearVelocity を毎 FixedUpdate で方向正規化 × 一定速に再設定

Goal/Out 衝突で演出の一時表示（IEnumerator ActivateTemporarily）

Out 時は ResetBall() で速度/角速度/位置/回転を初期化

🧱 ビルド手順（概要）

Windows（PCVR/Link）

Build Settings: PC, Mac & Linux Standalone（Windows, x86_64）

XR Plugin Management: Standalone の OpenXR を有効

Meta Quest（Android）

Platform を Android に切替

Scripting Backend: IL2CPP / Target Architectures: ARM64

XR Plugin Management: Android の OpenXR を有効、使用デバイスの Interaction Profile を追加

Scenes In Build にメインシーンを登録

📝 TODO / Ideas

スコア・UI（Goal 数、ミス回数、タイマー等）

連続ヒットのコンボ / 難易度（Goal サイズ、移動ターゲット）

ラケットのスイング方向を反映した反射（速さは一定で方向のみ変化）

エフェクト・SE・ハプティクスの強化

チュートリアル / 左利き対応 / 設定メニュー

⚖️ ライセンス / License

自作コード：MIT（必要に応じて変更してください）

外部アセット：各配布元のライセンスに従います（このリポジトリでは実体を同梱しません）

🙌 開発メモ（共有ルール）

.gitignore で Library/, Temp/, Build/ 等を除外

サードパーティ資産は除外（必要なら各自インポート）

可能なら Visible Meta Files / Force Text を有効にしてコラボしやすく
