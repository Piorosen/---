////////////////////////////////////////////////////////////////////////////////
// Filename: Rectclass.cpp
////////////////////////////////////////////////////////////////////////////////
#include "RectClass.h"


RectClass::RectClass()
{
	m_vertexBuffer = 0;
	m_indexBuffer = 0;
}


RectClass::RectClass(const RectClass& other)
{
}


RectClass::~RectClass()
{
}


bool RectClass::Initialize(ID3D11Device* device, D3DXVECTOR4 color, D3DXVECTOR3 position, D3DXVECTOR3 size)
{
	bool result;


	// Initialize the vertex and index buffers.
	result = InitializeBuffers(device, color, position, size);
	if (!result)
	{
		return false;
	}

	return true;
}


void RectClass::Shutdown()
{
	// Shutdown the vertex and index buffers.
	ShutdownBuffers();

	return;
}


void RectClass::Render(ID3D11DeviceContext* deviceContext, bool filled)
{
	// Put the vertex and index buffers on the graphics pipeline to prepare them for drawing.
	RenderBuffers(deviceContext, filled);

	return;
}


int RectClass::GetIndexCount()
{
	return m_indexCount;
}


bool RectClass::InitializeBuffers(ID3D11Device* device, D3DXVECTOR4 color, D3DXVECTOR3 position, D3DXVECTOR3 size)
{
	VertexType* vertices;
	unsigned long* indices;
	D3D11_BUFFER_DESC vertexBufferDesc, indexBufferDesc;
	D3D11_SUBRESOURCE_DATA vertexData, indexData;
	HRESULT result;


	// Set the number of vertices in the vertex array.
	m_vertexCount = 5;

	// Set the number of indices in the index array.
	m_indexCount = 5;

	// Create the vertex array.
	vertices = new VertexType[m_vertexCount];
	if (!vertices)
	{
		return false;
	}

	// Create the index array.
	indices = new unsigned long[m_indexCount];
	if (!indices)
	{
		return false;
	}
	for (int i = 0; i<m_indexCount; i++)
	{
		indices[i] = i;
	}

	float left, right, top, bottom;

	left = Lib_DIRECTXTOWINDOWX(position.x);
	right = Lib_WINDOWSIZEX(left, size.x);
	top = Lib_DIRECTXTOWINDOWY(position.y);
	bottom = Lib_WINDOWSIZEY(top, size.y);


	vertices[0].position = D3DXVECTOR3(left, top, 0.0f);
	vertices[0].color = color;

	vertices[1].position = D3DXVECTOR3(right, top, 0.0f);
	vertices[1].color = color;

	vertices[2].position = D3DXVECTOR3(right, bottom, 0.0f);
	vertices[2].color = color;

	vertices[3].position = D3DXVECTOR3(left, bottom, 0.0f);
	vertices[3].color = color;
	
	vertices[4].position = D3DXVECTOR3(left, top, 0.0f);
	vertices[4].color = color;


	vertexBufferDesc.Usage = D3D11_USAGE_DEFAULT;
	vertexBufferDesc.ByteWidth = sizeof(VertexType) * m_vertexCount;
	vertexBufferDesc.BindFlags = D3D11_BIND_VERTEX_BUFFER;
	vertexBufferDesc.CPUAccessFlags = 0;
	vertexBufferDesc.MiscFlags = 0;
	vertexBufferDesc.StructureByteStride = 0;

	// Give the subresource structure a pointer to the vertex data.
	vertexData.pSysMem = vertices;
	vertexData.SysMemPitch = 0;
	vertexData.SysMemSlicePitch = 0;

	// Now create the vertex buffer.
	result = device->CreateBuffer(&vertexBufferDesc, &vertexData, &m_vertexBuffer);
	if (FAILED(result))
	{
		return false;
	}

	// Set up the description of the static index buffer.
	indexBufferDesc.Usage = D3D11_USAGE_DEFAULT;
	indexBufferDesc.ByteWidth = sizeof(unsigned long) * m_indexCount;
	indexBufferDesc.BindFlags = D3D11_BIND_INDEX_BUFFER;
	indexBufferDesc.CPUAccessFlags = 0;
	indexBufferDesc.MiscFlags = 0;
	indexBufferDesc.StructureByteStride = 0;

	// Give the subresource structure a pointer to the index data.
	indexData.pSysMem = indices;
	indexData.SysMemPitch = 0;
	indexData.SysMemSlicePitch = 0;

	// Create the index buffer.
	result = device->CreateBuffer(&indexBufferDesc, &indexData, &m_indexBuffer);
	if (FAILED(result))
	{
		return false;
	}

	// Release the arrays now that the vertex and index buffers have been created and loaded.
	delete[] vertices;
	vertices = 0;

	delete[] indices;
	indices = 0;

	return true;
}


void RectClass::ShutdownBuffers()
{
	// Release the index buffer.
	if (m_indexBuffer)
	{
		m_indexBuffer->Release();
		m_indexBuffer = 0;
	}

	// Release the vertex buffer.
	if (m_vertexBuffer)
	{
		m_vertexBuffer->Release();
		m_vertexBuffer = 0;
	}

	return;
}


void RectClass::RenderBuffers(ID3D11DeviceContext* deviceContext, bool filled)
{
	unsigned int stride;
	unsigned int offset;

	// Set vertex buffer stride and offset.
	stride = sizeof(VertexType);
	offset = 0;

	// Set the vertex buffer to active in the input assembler so it can be rendered.
	deviceContext->IASetVertexBuffers(0, 1, &m_vertexBuffer, &stride, &offset);
	// Set the index buffer to active in the input assembler so it can be rendered.
	deviceContext->IASetIndexBuffer(m_indexBuffer, DXGI_FORMAT_R32_UINT, 0);

	// Set the type of primitive that should be rendered from this vertex buffer, in this case triangles.
	deviceContext->IASetPrimitiveTopology(filled ? D3D11_PRIMITIVE_TOPOLOGY_TRIANGLESTRIP : D3D11_PRIMITIVE_TOPOLOGY_LINESTRIP);

	return;
}