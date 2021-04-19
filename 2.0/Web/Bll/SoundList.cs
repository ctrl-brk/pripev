using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pripev.Model;

namespace Pripev.BLL
{
   public class SoundList : List<Sound>
   {
      private int _mp3Num = 0, _oggNum = 0, _wmaNum = 0;
      private int _asfNum=0, _movNum = 0, _aviNum = 0, _mpegNum = 0, _rmNum = 0;

      public SoundList() : base(10) {}

      public new void Add( Sound snd )
      {
         base.Add( snd );
         if ( snd.Type == SoundType.MP3 ) _mp3Num++;
         else if ( snd.Type == SoundType.Vorbis ) _oggNum++;
         else if ( snd.Type == SoundType.WMA ) _wmaNum++;
         else if ( snd.Type == SoundType.ASF ) _asfNum++;
         else if ( snd.Type == SoundType.AVI ) _aviNum++;
         else if ( snd.Type == SoundType.Mpeg ) _mpegNum++;
         else if ( snd.Type == SoundType.RealMovie ) _rmNum++;
      }

      public int SoundNum
      {
         get { return ( _mp3Num + _oggNum + _wmaNum ); }
      }

      public int VideoNum
      {
         get { return ( _asfNum + _movNum + _aviNum + _mpegNum + _rmNum ); }
      }

   }
}
