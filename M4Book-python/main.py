from turtle import onclick
from tinytag import TinyTag
from kivy.app import App
from kivy.uix.button import Button
from kivy.core.audio import SoundLoader



tag = TinyTag.get('В.Чиркова - Личный секретарь для младшего принца.m4b', image=True)




class MainApp(App):
    def build(self):
        btn = Button(text='Start', size_hint=(.5,.5))
        btn.bind(on_press=self.on_press_button)

        

        return btn
    
    def on_press_button(self, instance):
        print(tag.album         )# album as string
        print(tag.albumartist   )# album artist as string
        print(tag.artist        )# artist name as string
        print(tag.audio_offset  )# number of bytes before audio data begins
        print(tag.comment       )# bitrate in kBits/s
        print(tag.disc          )# disc number
        print(tag.disc_total    )# the total number of discs
        print(tag.duration      )# duration of the song in seconds
        print(tag.filesize      )# file size in bytes
        print(tag.genre         )# genre as string
        print(tag.samplerate    )# samples per second
        print(tag.title         )# title of the song
        print(tag.track         )# track number as string
        print(tag.track_total   )# total number of tracks as string
        print(tag.year          )# year or data as string
        print(tag.chapter_list)

        sound = SoundLoader.load('В.Чиркова - Личный секретарь для младшего принца.m4b')
        if sound:
            print("Sound found at %s" % sound.source)
            print("Sound is %.3f seconds" % sound.length)
            sound.play()
if __name__ == '__main__':
    app = MainApp()
    app.run()

    # не получается воспроизвести
    