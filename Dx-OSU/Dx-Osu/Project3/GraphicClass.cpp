#include "GraphicClass.h"

bool GraphicClass::Initialize(HWND hwnd)
{
	m_hwnd = hwnd;
	bool result;
	D3DXMATRIX baseViewMatrix;


	result = m_D3D->Initialize(screenWidth, screenHeight, VSYNC_ENABLED, hwnd, FULL_SCREEN, SCREEN_DEPTH, SCREEN_NEAR);

	m_Camera->SetPosition(screenWidth / 2, screenHeight / 2, -10);
	m_Camera->Render();
	m_Camera->GetViewMatrix(baseViewMatrix);

	m_sound->Initialize(hwnd, const_cast<char*>("C:\\Map\\Data\\sound02.wav"));

	m_shapeshader->Initialize(m_D3D->GetDevice(), hwnd);

	list = m_mr.GetMusic("C:\\Map\\music.txt");

	for (int i = 0; i < list.size(); i++) {
			CircleClass* cir = new CircleClass;
			cir->Initialize(m_D3D->GetDevice(), D3DXVECTOR4(1, 1, 0.5, 1), D3DXVECTOR3(list[i].x - 1920 / 2, list[i].y - 1080 / 2, 0), 50);
			m_rect.push_back(cir);
	}

	m_Text->Initialize(m_D3D->GetDevice(), m_D3D->GetDeviceContext(), hwnd, baseViewMatrix);
	return true;
}


void GraphicClass::Shutdown()
{
	if (m_sound) {
		m_sound->Shutdown();
		delete m_sound;
		m_sound = 0;
	}

	if(m_Text)
	{
		m_Text->Shutdown();
		delete m_Text;
		m_Text = 0;
	} 
	if (m_Camera)
	{
		delete m_Camera;
		m_Camera = 0;
	}

	if (m_D3D)
	{
		m_D3D->Shutdown();
		delete m_D3D;
		m_D3D = 0;
	}

	return;
}


bool GraphicClass::Frame(int i, D3DXVECTOR2 mouse, int cpu, int fps, float timer)
{
	
	
	bool result;
	m_Text->SetMousePosition((float)fps, (float)cpu, m_D3D->GetDeviceContext());
	result = Render(i, mouse);
	if (!result)
	{
		return false;
	}

	return true;
}


bool GraphicClass::Render(int w, D3DXVECTOR2 mouse)
{
	D3DXMATRIX worldMatrix, viewMatrix, projectionMatrix, orthoMatrix;

	flow = clock();
	m_D3D->BeginScene(0.6f, 0.6f, 0.6f, 1.0f);

	m_Camera->Render();
	m_Camera->GetViewMatrix(viewMatrix);

	m_D3D->GetWorldMatrix(worldMatrix);
	m_D3D->GetProjectionMatrix(projectionMatrix);
	m_D3D->GetOrthoMatrix(orthoMatrix);
	m_D3D->TurnOnAlphaBlending();
	
	static int score = 0;


	// 흐른 시간 > 블럭시간
	// 
	time_t late = flow - start;
	for (int i = 0; i < m_rect.size(); i++) {
		if (list[i].time - 200 < late && late < list[i].time + 200) {
			if (w == 1000) {
				if (list[i].x - 25 <= mouse.x && mouse.x <= list[i].x + 25
					&&
					1080 - list[i].y - 25 <= mouse.y && mouse.y <= 1080 - list[i].y + 25)
				{
					m_sound->PlayWaveFile(0, 0, 0);
					score++;
					
				}
			}
		}


		if (list[i].time - 200 < late && late < list[i].time + 200) {

			m_rect[i]->Render(m_D3D->GetDeviceContext(), true);
			m_shapeshader->Render(m_D3D->GetDeviceContext(), m_rect[i]->GetIndexCount(), worldMatrix, viewMatrix, orthoMatrix);

		}

	}
	m_Text->SetScore(score, m_D3D->GetDeviceContext());

	m_Text->Render(m_D3D->GetDeviceContext(), worldMatrix, orthoMatrix);
	
	m_D3D->EndScene();
		
	return true;
}