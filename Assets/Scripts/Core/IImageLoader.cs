using UnityEngine;

public interface IImageLoader
{
    AsyncResponse<Sprite[]> LoadAllImages();
}
