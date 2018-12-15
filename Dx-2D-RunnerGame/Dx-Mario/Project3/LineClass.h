#pragma once

//////////////
// INCLUDES //
//////////////
#include <d3d11.h>
#include <D3DX10math.h>
#include <cmath>

////////////////////////////////////////////////////////////////////////////////
// Class name: ModelClass
////////////////////////////////////////////////////////////////////////////////
class LineClass
{
private:
	struct VertexType
	{
		D3DXVECTOR3 position;
		D3DXVECTOR4 color;
	};

public:
	LineClass();
	LineClass(const LineClass&);
	~LineClass();

	bool Initialize(ID3D11Device*, D3DXVECTOR4 color, D3DXVECTOR3 StartPoint, D3DXVECTOR3 EndPoint, double Thin);
	void Shutdown();
	void Render(ID3D11DeviceContext*);

	int GetIndexCount();

private:
	bool InitializeBuffers(ID3D11Device*, D3DXVECTOR4 color, D3DXVECTOR3 StartPoint, D3DXVECTOR3 EndPoint, double Thin);
	void ShutdownBuffers();
	void RenderBuffers(ID3D11DeviceContext*);

private:
	ID3D11Buffer * m_vertexBuffer, *m_indexBuffer;
	int m_vertexCount, m_indexCount;
};