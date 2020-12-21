using UnityEngine;
using UnityEditor;
using System.Collections;

public class ImportProcess : AssetPostprocessor
{
    //画像のインポート時、インポート設定変更時に実行される関数
    void OnPreprocessTexture()
    {
        //assetImporterにインポートするオブジェクトが入る。それをテクスチャ型にキャスト
        TextureImporter Ti = assetImporter as TextureImporter;

        //インポート設定変更時もこのメソッドが呼ばれる都合上、一部のテクスチャだけ初期設定を無効化するには何かしらの処理が必要
        //今回はパッキングタグが何かしら設定されている場合、初期設定を行わないように設定する
        if (Ti.spritePackingTag != "")
        {
            return;
        }

        //今回は全てスプライト扱いにする
        Ti.textureType = TextureImporterType.Sprite;
        Ti.mipmapEnabled = false;
        Ti.textureCompression = TextureImporterCompression.Compressed;

       
        Ti.spriteImportMode = SpriteImportMode.Single;
        Ti.filterMode = FilterMode.Bilinear;
        Ti.maxTextureSize = 2048;
        
    }
}
