#pragma once

#include <d3d11.h>
#include <D3DX10math.h>
#include <vector>

#include "Global.h"

class CircleClass
{
private:
	struct VertexType
	{
		VertexType(D3DXVECTOR3 p, D3DXVECTOR4 c) : position(p) , color(c){}
		D3DXVECTOR3 position;

		D3DXVECTOR4 color;
	};

public:


	bool Initialize(ID3D11Device*, D3DXVECTOR4 color, D3DXVECTOR3 position, float radius);
	void Shutdown();
	void Render(ID3D11DeviceContext*, bool);

	int GetIndexCount();

private:
	bool InitializeBuffers(ID3D11Device*, D3DXVECTOR4 color, D3DXVECTOR3 position, float radius);
	void ShutdownBuffers();
	void RenderBuffers(ID3D11DeviceContext*, bool);

private:
	ID3D11Buffer * m_vertexBuffer;
	int m_vertexCount;
};