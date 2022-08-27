﻿#region "copyright"

/*
    Copyright Dale Ghent <daleg@elemental.org> and contributors

    This Source Code Form is subject to the terms of the Mozilla Public
    License, v. 2.0. If a copy of the MPL was not distributed with this
    file, You can obtain one at http://mozilla.org/MPL/2.0/
*/

#endregion "copyright"

using System;
using System.Collections.Generic;
using System.Linq;
using System.Speech.Synthesis;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace DaleGhent.NINA.GroundStation.TTS {

    internal class TTS {
        private static SpeechSynthesizer synthesizer;

        static TTS() {
            synthesizer = new SpeechSynthesizer();
        }

        private string GetVoice() {
            lock (synthesizer) {
                List<VoiceInfo> voices = new List<VoiceInfo>();

                foreach (var voice in synthesizer.GetInstalledVoices()) {
                    if (voice.Enabled) {
                        voices.Add(voice.VoiceInfo);
                    }
                }
                if (voices.Count == 0) {
                    return null;
                }

                // Find voice matching the selected UI culture - fallback to first found voice if no match
                var localeVoice = voices.FirstOrDefault(x => x.Culture.Name == Dispatcher.CurrentDispatcher.Thread.CurrentUICulture.Name);
                if (localeVoice == null) {
                    return voices.First().Name;
                } else {
                    return localeVoice.Name;
                }
            }
        }

        public bool HasVoice() {
            return GetVoice() != null;
        }

        public async Task Speak(string text, CancellationToken token) {
            var voice = GetVoice();
            if (voice != null) {
                while (synthesizer.State == SynthesizerState.Speaking) {
                    await Task.Delay(100, token);
                }

                synthesizer.SetOutputToDefaultAudioDevice();
                synthesizer.SelectVoice(voice);
                synthesizer.SpeakAsync(text);

                while (synthesizer.State == SynthesizerState.Speaking) {
                    await Task.Delay(100, token);
                }
            }
        }
    }
}