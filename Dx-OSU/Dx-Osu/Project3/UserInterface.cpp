#include "UserInterface.h"

void UserInterface::Shutdown()
{
	for (auto* draw : List_Bitmap) {
		draw->Shutdown();
	}
	for (auto* draw : List_Line) {
		draw->Shutdown();
	}
	for (auto* draw : List_Rect) {
		
		draw->Shutdown();
	}
	for (auto* draw : List_Circle) {
		draw->Shutdown();
	}
	m_shapeClass->Shutdown();
	m_textureClass->Shutdown();
}

bool UserInterface::Render(ID3D11DeviceContext *deviceContext,D3DMATRIX worldMatrix, D3DMATRIX viewMatrix, D3DMATRIX orthoMatrix)
{
	if (!List_Bitmap.empty()) {
		for (BitmapClass* bitmap : List_Bitmap) {
			bitmap->Render(deviceContext);
			m_textureClass->Render(deviceContext, bitmap->GetIndexCount(), worldMatrix, m_baseCameraMatrix, orthoMatrix, bitmap->GetTexture());
		}

	}

	if (!List_Line.empty()) {
		for (LineClass* line : List_Line) {
			line->Render(deviceContext);
			m_shapeClass->Render(deviceContext, line->GetIndexCount(), worldMatrix, m_baseCameraMatrix, orthoMatrix);
		}
	}

	if (!List_Rect.empty()) {
		for (RectClass* rect : List_Rect) {
			rect->Render(deviceContext, true);
			m_shapeClass->Render(deviceContext, rect->GetIndexCount(), worldMatrix, m_baseCameraMatrix, orthoMatrix);
		}
	}

	return true;
}

void UserInterface::Initialize(ID3D11Device *device, HWND hwnd, D3DMATRIX camera)
{
	List_Bitmap.clear();
	List_Line.clear();
	List_Rect.clear();
	List_Circle.clear();

	m_baseCameraMatrix = camera;
	m_shapeClass = new ShapeShaderClass;
	m_shapeClass->Initialize(device, hwnd);

	m_textureClass = new TextureShaderClass;
	m_textureClass->Initialize(device, hwnd);

}
