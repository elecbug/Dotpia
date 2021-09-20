﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dotpia
{
    public partial class Helper : Form
    {
        public Helper()
        {
            InitializeComponent();
        }

        private string[] strValue = {"안녕 도트 툴 없는 친구들!",
                                     "내 툴을 사용하기 편하도록 몇 가지 도움을 주려고 해.",
                                     "기능 소개니까 툴을 최대한 활용하려면 잘 봐둬!",
                                     " ",
                                     "주의사항!",
                                     "1. 본 프로그램은 매우 구닥다리이므로 100*100 px만 되어도 견딜 수가 없습니다. 작은 도트용으로만 사용하시기 바랍니다. (수정: 저것보단 나아졌으나, 그래도 가급적 작은 도트 위주로 진행하길 권장합니다.)",
                                     "2. 본 프로그램은 세이브 권유를 하지 않으며, X키를 누를 경우 항상 한 단계 질문만을 수행합니다. 실수로 나가지 않게 주의하십시오.",
                                     "3. 데이터 로드 시 처음 10초 정도는 부팅 시간이라 느릴 수 있습니다. (만일 로드가 되지 않았다면 Zoom Reset 버튼을 눌러 수동으로 로드하시기 바랍니다.)",
                                     "Tip! BitMap 창이 뜨자마자 마우스를 겁나 흔들고 5초정도 마우스를 놓아두면 최고속도로 부팅이 됩니다.",
                                     "4. Border가 ON 되어 있다면 연속 선 긋기가 끊길 수 있습니다. (수정됨)",
                                     "5. Paint로 한 번에 넓은 영역을 색칠할 경우 프로그램이 터질 수 있습니다. (농담아닙니다. 진짜 말 그대로 터집니다.) (수정됨)",
                                     "6. BitMap 화면에 Scroll Bar가 있기는 하나, 렉이 심하니 가급적 사용하시지 않으시기 바랍니다. (수정중)",
                                     " ",
                                     "Main 화면",
                                     "Pencil Case 버튼:  필통을 불러옵니다.",
                                     "Width 칸: 새로 파일을 만들 때 설정할 가로 너비를 입력하는 칸 입니다.",
                                     "Heitght 칸: 새로 파일을 만들 때 설정한 세로 너비를 입력하는 칸 입니다.",
                                     "New 버튼: 새로 파일을 만들 위치를 선택합니다. (지원 포맷 *.png)",
                                     "Load 버튼: 불러올 기존 파일을 선택합니다. (지원 포맷 *.png)",
                                     "Load Dotpia 버튼: 불러올 기존 파일을 선택합니다. (지원 포맷 *.dotpia)",
                                     "New 혹은 Load 버튼을 누르면 BitMap 화면으로 넘어가며 작업을 시작하실 수 있습니다.",
                                     " ",
                                     "BitMap 화면",
                                     "클릭: 해당 비트에서 작업을 수행합니다.",
                                     "우클릭: 해당 비트를 투명하게 칠합니다.",
                                     "드래그: 연속 선 긋기 모드가 되어, 부드럽게 선이 그어집니다.",
                                     "더블 클릭: 연속 선 긋기 모드가 되어, 드래그와 유사하나, 마우스 버튼을 떼고 있어도 연속으로 선이 그어집니다.",
                                     "마우스 휠: 줌 인 / 줌 아웃 합니다.",
                                     "Ctrl+Z 키: BitMap을 한 단계 이전으로 되돌립니다.",
                                     "Ctrl+V 키: 클립보드에 복사된 이미지를 현재 레이어에 붙여넣습니다.",
                                     "Ctrl+마우스 휠: 연필의 크기를 키우거나 줄입니다.",
                                     "Scroll Bar: 보고있는 패널을 움직입니다.",
                                     " ",
                                     "Pencil Case 화면(중요!)",
                                     "Border 버튼: BitMap 화면에 격자 무늬를 표시합니다.",
                                     "Extrain 버튼(활성화): BitMap의 비트에서 색상을 추출하여 현재 색상에 대입합니다.",
                                     "Paint 버튼(활성화): BitMap의 해당 비트와 직접 연결된 색상이 같은 모든 비트에 현재 색상을 칠합니다.",
                                     "Mirror 버튼(활성화/2단계(수평/수직)): 수평/수직 대칭자를 설치하여 대칭으로 그림을 자동으로 그려줍니다.",
                                     "Layer 버튼: Layer 창을 활성화 합니다.",
                                     "Zoom Set 버튼: 줌을 원래대로 되돌립니다.",
                                     "Ctrl+Z 버튼: BitMap을 한 단계 이전으로 되돌립니다.",
                                     "Ctrl+V 버튼: 클립보드에 복사된 이미지를 현재 레이어에 붙여넣습니다.",
                                     "색상 네모와 RGBA값: 현재 색상과 RGBA값을 표시합니다.",
                                     "작은 색상 네모와 할당 버튼: 작은 색상 내모를 누르면 그 색상으로 현재 색상이 변경되며, 아래의 할당 버튼을 누르면 그 칸에 현재 색상이 해당 작은 색상 네모에 할당됩니다.",
                                     "Smart Set 버튼: ColorDialog를 통한 현재 색상 값을 재설정합니다.",
                                     "Save 버튼: 현재 BitMap을 *.png로 저장합니다.",
                                     "Save Dotpia 버튼: 현재 BitMap을 *.dotpia로 저장하여 현재 편집 상태를 그대로 유지합니다.",
                                     "Export 버튼: 옆의 숫자만큼 배율을 설정하여 현재 BitMap을 저장합니다.",
                                     "Combine 버튼: 기존의 *.png 파일들을 합쳐줍니다. 옆에 입력된 가로와 세로 값 만큼 같은 크기의 *.png 파일을 합쳐서 다시 저장합니다.",
                                     "Width/Height 라벨: 초기 설정했던 너비/높이 값입니다.",
                                     "Mouse Position 라벨: 마우스의 현재 위치를 나타냅니다.",
                                     "Px 라벨: 마우스의 현재 픽셀을 가져옵니다.",
                                     " ",
                                     "Layer 화면",
                                     "숫자 체크 박스는 현재 선택된 레이어, 그 옆의 숫자는 옆의 레이어의 불투명도입니다.",
                                     "U/D 버튼: U 버튼은 해당 레이어를 상승 시키고, D 버튼은 해당 레이어를 하강 시킵니다."};

        private void Helper_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < strValue.Length; i++)
            {
                Rtb.Text += strValue[i];
                Rtb.Text += "\r\n\r\n";
            }
        }
    }
}
