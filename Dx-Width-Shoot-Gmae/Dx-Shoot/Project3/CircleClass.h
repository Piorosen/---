#pragma once

#include <d3d11.h>
#include <D3DX10math.h>

#include "Global.h"

class CircleClass
{
private:
	struct VertexType
	{
		D3DXVECTOR3 position;
		D3DXVECTOR4 color;
	};

public:
	CircleClass();
	CircleClass(const CircleClass&);
	~CircleClass();

	bool Initialize(ID3D11Device*, D3DXVECTOR4 color, D3DXVECTOR3 position, D3DXVECTOR3 size);
	void Shutdown();
	void Render(ID3D11DeviceContext*);

	int GetIndexCount();

private:
	bool InitializeBuffers(ID3D11Device*, D3DXVECTOR4 color, D3DXVECTOR3 position, D3DXVECTOR3 size);
	void ShutdownBuffers();
	void RenderBuffers(ID3D11DeviceContext*);

private:
	ID3D11Buffer * m_vertexBuffer, *m_indexBuffer;
	int m_vertexCount, m_indexCount;
};