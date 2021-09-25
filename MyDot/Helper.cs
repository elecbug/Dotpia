using System;
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

        private bool bolKE = true;
        private string[] strValueK = {"주의사항!",
                                     "1. 본 프로그램은 매우 구닥다리이므로 100*100 px만 되어도 견딜 수가 없습니다. 작은 도트용으로만 사용하시기 바랍니다. (수정: 저것보단 나아졌으나, 그래도 가급적 작은 도트 위주로 진행하길 권장합니다.)",
                                     "2. 본 프로그램은 세이브 권유를 하지 않으며, X키를 누를 경우 항상 한 단계 질문만을 수행합니다. 실수로 나가지 않게 주의하십시오.",
                                     "3. 데이터 로드 시 처음 10초 정도는 부팅 시간이라 느릴 수 있습니다. (만일 로드가 되지 않았다면 Zoom Reset 버튼을 눌러 수동으로 로드하시기 바랍니다.)",
                                     "4. 마우스를 너무 빠르게 움직이면 연속 선 긋기가 끊길 수 있습니다.",
                                     "",
                                     "Main 화면",
                                     "Width 칸: 새로 파일을 만들 때 설정할 가로 너비를 입력하는 칸 입니다.",
                                     "Heitght 칸: 새로 파일을 만들 때 설정한 세로 너비를 입력하는 칸 입니다.",
                                     "New 버튼: 새로 파일을 만들 위치를 선택합니다. (지원 포맷 *.png)",
                                     "Load 버튼: 불러올 기존 파일을 선택합니다. (지원 포맷 *.png *.jpg)",
                                     "Load Dotpia 버튼: 불러올 기존 파일을 선택합니다. (지원 포맷 *.dotpia)",
                                     "New 혹은 Load / Load Dotpia 버튼을 누르면 BitMap 화면으로 넘어가며 작업을 시작하실 수 있습니다.",
                                     "",
                                     "BitMap 화면",
                                     "클릭: 해당 비트에서 작업을 수행합니다.",
                                     "우클릭: 해당 비트를 투명하게 칠합니다.",
                                     "드래그: 연속 선 긋기 모드가 되어, 부드럽게 선이 그어집니다.",
                                     "더블 클릭: 연속 선 긋기 모드가 되어, 드래그와 유사하나, 마우스 버튼을 떼고 있어도 연속으로 선이 그어집니다.",
                                     "마우스 휠: 줌 인 / 줌 아웃 합니다.",
                                     "Ctrl+Z 키: BitMap을 한 단계 이전으로 되돌립니다.",
                                     "Ctrl+V 키: 클립보드에 복사된 이미지를 현재 레이어에 붙여넣습니다.",
                                     "Ctrl+마우스 휠: 연필의 크기를 키우거나 줄입니다.",
                                     "",
                                     "Pencil Case 화면(중요!)",
                                     "Border 버튼: BitMap 화면에 격자 무늬를 표시합니다.",
                                     "Extrain 버튼(활성화): BitMap의 비트에서 색상을 추출하여 현재 색상에 대입합니다.",
                                     "Paint 버튼(활성화): BitMap의 해당 비트와 직접 연결된 색상이 같은 모든 비트에 현재 색상을 칠합니다.",
                                     "Mirror 버튼(활성화/2단계(수평/수직)): 수평/수직 대칭자를 설치하여 대칭으로 그림을 자동으로 그려줍니다.",
                                     "Zoom Reset 버튼: 줌을 원래대로 되돌립니다.",
                                     "Ctrl+Z 버튼: BitMap을 한 단계 이전으로 되돌립니다.",
                                     "Ctrl+V 버튼: 클립보드에 복사된 이미지를 현재 레이어에 붙여넣습니다.",
                                     "Cut 버튼: 비트맵에 범위를 지정 후, \r\n" +
                                     "1. 해당 범위를 드래그하여 범위를 잘라내어 옮길 수 있습니다.\r\n" +
                                     "2. 해당 범위를 옮기며 Ctrl 키를 누르면 옮기는 대신 영역을 복사합니다.\r\n" +
                                     "3. Ctrl+C 키를 누르면 해당 영역이 임시 보드에 저장이 됩니다. 이후 Ctrl+V 키를 이용하여 영역을 붙여 넣을 수 있습니다.\r\n" +
                                     "4. Shift+H/V 키를 누르면 각각 수평/수직으로 영역이 반전됩니다.\r\n" +
                                     "5. Ctrl+X 키를 누르면 해당 영역을 잘라내어 임시 보드에 저장이 됩니다. 이후 Ctrl+V 키를 이용하여 영역을 붙여 넣을 수 있습니다.\r\n" +
                                     "6. Delete 키를 누르면 해당 영역을 삭제합니다.",
                                     "Resize 버튼: 해당 값으로 BitMap 크기를 재설정 합니다. 이때 재 설정하고 난 뒤로는 Ctrl+Z 기능을 이용하여 재설정 하기 전으로 돌아가실 수 없으니 주의하시기 바랍니다.",
                                     "색상 네모와 RGBA값: 현재 색상과 RGBA값을 표시합니다.",
                                     "작은 색상 네모와 할당 버튼: 작은 색상 내모를 누르면 그 색상으로 현재 색상이 변경되며, 아래의 할당 버튼을 누르면 그 칸에 현재 색상이 해당 작은 색상 네모에 할당됩니다.",
                                     "Smart Set 버튼: ColorDialog를 통한 현재 색상 값을 재설정합니다.",
                                     "Save 버튼: 현재 BitMap을 *.png *.jpg로 저장합니다.",
                                     "Save Dotpia 버튼: 현재 BitMap을 *.dotpia로 저장하여 현재 편집 상태를 그대로 유지합니다.",
                                     "Export 버튼: 옆의 숫자만큼 배율을 설정하여 현재 BitMap을 저장합니다.",
                                     "Combine 버튼: 기존의 *.png 파일들을 합쳐줍니다. 옆에 입력된 가로와 세로 값 만큼 같은 크기의 *.png 파일을 합쳐서 다시 저장합니다.",
                                     "Width/Height 라벨: 초기 설정했던 너비/높이 값입니다.",
                                     "Mouse Position 라벨: 마우스의 현재 위치를 나타냅니다.",
                                     "Px 라벨: 마우스의 현재 픽셀을 가져옵니다.",
                                     "",
                                     "Layer 화면",
                                     "숫자 체크 박스는 현재 선택된 레이어, 그 옆의 숫자는 옆의 레이어의 불투명도입니다.",
                                     "U/D 버튼: U 버튼은 해당 레이어를 상승 시키고, D 버튼은 해당 레이어를 하강 시킵니다."};
        private string[] strValueE = {"CAUTION!",
                                     "1. This program is very outdated, so even 100*100 px cannot be tolerated. Please use only for small dots. (Modification: It is better than that, but it is recommended to proceed with small dots as much as possible.)",
                                     "2. This program does not recommend a save, and if you press the X key, only one level question is always performed. Be careful not to accidentally go out.",
                                     "3. When loading data, the first 10 seconds or so may be slow due to boot time. (If it is not loaded, click the Zoom Reset button to manually load it.)",
                                     "4. If you move the mouse too fast, continuous line drawing may be interrupted.",
                                     "",
                                     "Main Screen",
                                     "Width Field: This is the field to input the horizontal width to set when creating a new file.",
                                     "Heitght Field: This is the field to enter the vertical width set when creating a new file.",
                                     "New Button: Select the location to create a new file. (Supported format *.png)",
                                     "Load Button: select an existing file to load. (Supported formats *.png *.jpg)",
                                     "Load Dotpia Button: select an existing file to load. (Supported format *.dotpia)",
                                     "If you press the New or Load / Load Dotpia button, you can go to the BitMap screen and start working.",
                                     "",
                                     "BitMap Screen",
                                     "Click: Perform an action on that bit.",
                                     "Right-click: Make the corresponding bit transparent.",
                                     "Drag: Enters continuous line drawing mode, drawing smooth lines.",
                                     "Double click: Enters continuous line drawing mode, similar to dragging, but continuous lines are drawn even when the mouse button is released.",
                                     "Mouse wheel: zoom in / zoom out.",
                                     "Ctrl+Z: Reverts the BitMap one step back.",
                                     "Ctrl+V: Pastes the image copied to the clipboard to the current layer.",
                                     "Ctrl+Mouse Wheel: Increase or decrease the size of the pencil.",
                                     "",
                                     "Pencil Case Screen (Important!)",
                                     "Border Button: Display a grid on the BitMap screen.",
                                     "Extrain Button (enable): Extracts a color from a bit in the BitMap and assigns it to the current color.",
                                     "Paint Button (enabled): Paints the current color on all bits that have the same color directly associated with that bit in the BitMap.",
                                     "Mirror Button (Enable/2 Levels (Horizontal/Vertical)): Install horizontal/vertical mirrors to automatically draw symmetrical pictures.",
                                     "Zoom Reset Button: Returns the zoom to normal.",
                                     "Ctrl+Z Button: reverts the BitMap one step back",
                                     "Ctrl+V Button: Pastes the image copied to the clipboard to the current layer.",
                                     "Cut Button: after specifying a range on the bitmap, \r\n" +
                                     "1. You can cut and move the range by dragging it.\r\n" +
                                     "2. If you press the Ctrl key while moving the range, it copies the area instead of moving it.\r\n" +
                                     "3. If you press Ctrl+C, the area is saved on the temporary board. After that, you can paste the area using Ctrl+V keys.\r\n" +
                                     "4. Press Shift+H/V to invert the area horizontally/vertically, respectively.\r\n" +
                                     "5. Press Ctrl+X to cut the area and save it to the temporary board. After that, you can use Ctrl+V to paste the area.\r\n" +
                                     "6. Press the Delete key to delete the area.",
                                     "Resize Button: Resets the BitMap size to the corresponding value. Please note that after resetting at this time, you cannot return to the previous setting using the Ctrl+Z function.",
                                     "Color rectangle and RGBA values: Displays the current color and RGBA values.",
                                     "Small color square and assign Button: Tapping the little color square changes the current color to that color, and clicking the assign button below assigns the current color to that little color square.",
                                     "Smart Set button: resets the current color value via ColorDialog.",
                                     "Save Button: Save the current BitMap as *.png *.jpg",
                                     "Save Dotpia Button: Saves the current BitMap as *.dotpia, keeping the current edit state.",
                                     "Export Button: Save the current BitMap by setting the magnification by the number next to it.",
                                     "Combine Button: Combines existing *.png files. Combines *.png files with the same size as the horizontal and vertical values ​​entered next and saves them again.",
                                     "Width/Height Label: The initially set width/height values.",
                                     "Mouse Position Label: Indicates the current position of the mouse.",
                                     "Px Label: Get the current pixel of the mouse.",
                                     "",
                                     "Layer Screen",
                                     "The number checkbox is the currently selected layer, the number next to it is the opacity of the layer next to it.",
                                     "U/D Button: U button raises that layer, D button lowers that layer."};

        private void Helper_Load(object sender, EventArgs e)
        {
            BtnKE_Click(sender, e);
        }

        private void BtnKE_Click(object sender, EventArgs e)
        {
            Rtb.Text = "";
            if(!bolKE)
            {
                bolKE = true;
                BtnKE.Text = "한국어로 전환";
                for (int i = 0; i < strValueE.Length; i++)
                {
                    Rtb.Text += strValueE[i];
                    if (i != strValueE.Length - 1)
                    {
                        Rtb.Text += "\r\n\r\n";
                    }
                }
            }
            else if (bolKE)
            {
                bolKE = false;             
                BtnKE.Text = "Changed English";
                for (int i = 0; i < strValueK.Length; i++)
                {
                    Rtb.Text += strValueK[i];
                    if (i != strValueK.Length - 1)
                    {
                        Rtb.Text += "\r\n\r\n";
                    }
                }
            }
        }
    }
}
