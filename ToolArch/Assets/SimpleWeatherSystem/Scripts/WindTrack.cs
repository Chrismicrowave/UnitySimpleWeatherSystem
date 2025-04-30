using UnityEditor.Timeline;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

namespace SimpleWeatherSystem
{
    [TrackColor(241 / 255f, 249 / 255f, 99 / 255f)]
    [TrackBindingType(typeof(WindSystem))]
    [TrackClipType(typeof(WindSystemClip))]

    public class WindTrack : TrackAsset
    {
        protected override void OnCreateClip(TimelineClip clip)
        {
            base.OnCreateClip(clip);

#if UNITY_EDITOR
            var director = TimelineEditor.inspectedDirector;
            if (director != null)
            {
                var binding = director.GetGenericBinding(this) as WindSystem;
                if (binding != null)
                {
                    clip.displayName = binding.gameObject.name + " - Clip";
                    return;
                }
            }
#endif
            clip.displayName = "Weather Clip";
        }
    }
}